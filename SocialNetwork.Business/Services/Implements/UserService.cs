using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Friendship.Requests;
using SocialNetwork.Business.DTOs.Message.Requests;
using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.DTOs.Post.Responses;
using SocialNetwork.Business.DTOs.Token;
using SocialNetwork.Business.DTOs.Token.Requests;
using SocialNetwork.Business.DTOs.User.Requests;
using SocialNetwork.Business.DTOs.User.Responses;
using SocialNetwork.Business.Helper;
using SocialNetwork.Business.Services.Implements.Base;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using SocialNetwork.DataAccess.Utilities.Roles;
using System.Linq.Expressions;

namespace SocialNetwork.Business.Services.Implements
{
    public class UserService : BaseServices<UserService>, IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        private readonly IPostService _postService;
        private readonly IFriendshipService _friendshipService;
        private readonly IMessageService _messageService;
        private readonly INotificationService _notificationService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(IUnitOfWork unitOfWork,
                           IMapper mapper,
                           ILogger<UserService> logger,
                           UserManager<User> userManager,
                           ITokenService tokenService,
                           SignInManager<User> signInManager,
                           IPostService postService,
                           IFriendshipService friendshipService,
                           IMessageService messageService,
                           INotificationService notificationService,
                           RoleManager<IdentityRole> roleManager) : base(unitOfWork, mapper, logger)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _postService = postService;
            _friendshipService = friendshipService;
            _messageService = messageService;
            _notificationService = notificationService;
            _roleManager = roleManager;
        }

        #region Auth + User info

        public async Task<IResponse> GetAll(string? searchString, int pageSize, int pageNumber)
        {
            Expression<Func<User, bool>> filter;

            if (searchString != null)
            {
                filter = x => (x.FirstName + " " + x.LastName).Contains(searchString) && x.Status == 1;
            }   
            else
            {
                filter = x => x.Status == 1;
            }

            int totalItems = await _unitOfWork.UserRepository.Count(filter);
            int pageCount = (int)Math.Ceiling((double)totalItems / pageSize);
            if (pageNumber > pageCount && pageCount > 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }    

            var users = await _unitOfWork.UserRepository.GetPaged(pageSize, pageNumber, filter, x => x.FirstName, false);
            return new PagedResponse<List<GetUserResponse>>(_mapper.Map<List<GetUserResponse>>(users), totalItems, 200);
        }

        public async Task<IResponse> Register(RegistrationRequest request)
        {
            var checkExistUser = await _userManager.FindByEmailAsync(request.Email);
            if (checkExistUser != null && checkExistUser.Status != 0)
            {
                return new ErrorResponse(400, Messages.EmailUsed);
            }

            var user = _mapper.Map<User>(request);
            var result = await _userManager.CreateAsync(user, user.Password);
            if (!result.Succeeded)
            {
                return new ErrorResponse(400, result.GetErrors());
            }

            var token = await _tokenService.CreateToken(user);

            return new DataResponse<Token>(token, 201, Messages.RegistrationSuccessfully);
        }

        public async Task<IResponse> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.IncorrectEP);
            }    

            var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!signInResult.Succeeded)
            {
                return new ErrorResponse(400, signInResult.GetErrors());
            }

            var token = await _tokenService.CreateToken(user);

            var response = _mapper.Map<UserWithTokenResponse>(user);
            response.Token = token;


            return new DataResponse<UserWithTokenResponse>(response, 200, Messages.LoginSuccessfully);
        }

        public async Task<IResponse> ForgotPassword(ForgotPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }    

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            return new DataResponse<ForgotPasswordCodeResponse>(new ForgotPasswordCodeResponse(code), 200, Messages.GetCodeResetPassword);
        }

        public async Task<IResponse> ResetPassword(ResetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }    

            var result = await _userManager.ResetPasswordAsync(user, request.Code, request.Password);

            if (result.Succeeded)
            {
                var token = await _tokenService.CreateToken(user);
                return new DataResponse<Token>(token, 200, Messages.ResetPasswordSuccessfully);
            }   
            else
            {
                return new ErrorResponse(400, result.GetErrors());
            }    

        }

        public async Task<IResponse> GetById(string loggedUserId, string requestUserId)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }    

            var user = await _userManager.FindByIdAsync(requestUserId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            return new DataResponse<GetUserResponse>(_mapper.Map<GetUserResponse>(user), 200);
        }

        public async Task<IResponse> UpdateInfo(string loggedUserId, string requestUserId, UpdateUserInfoRequest request)
        {
            if(!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            var updateUser = _mapper.Map<User>(request);
            updateUser.Id = requestUserId;

            await _unitOfWork.UserRepository.Update(updateUser);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.UpdateError);
            }

            var userUpdated = await _userManager.FindByIdAsync(requestUserId);

            return new DataResponse<GetUserResponse>(_mapper.Map<GetUserResponse>(userUpdated), 204, Messages.UpdatedSuccessfully);

        }

        public async Task<IResponse> DeleteUser(string loggedUserId, string requestUserId)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            var user = await _userManager.FindByIdAsync(requestUserId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }

            await _unitOfWork.UserRepository.Delete(user.Id);

            var result = await _unitOfWork.CompleteAsync();
            if (!result)
            {
                return new ErrorResponse(400, Messages.STWrong);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);
        }

        public async Task<IResponse> ChangePassword(string loggedUserId, ChangePasswordRequest request)
        {
            var user = await _userManager.FindByIdAsync(loggedUserId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound());
            }    

            if (user.Email != request.Email)
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }    

            var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);

            if (!result.Succeeded)
            {
                return new ErrorResponse(400, result.GetErrors());
            }

            return new SuccessResponse(Messages.ChangePasswordSuccessfully, 204);
        }

        public async Task<IResponse> AddRoles(string userId, AddRolesToUserRequest request)
        {
            if (request.Roles == null || request.Roles.Count == 0)
            {
                return new ErrorResponse(400, Messages.RoleEmpty);
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }

            if (!(await CheckRoleValid(request.Roles)))
            {
                return new ErrorResponse(400, Messages.InvalidRole);
            }

            var result = await _userManager.AddToRolesAsync(user, request.Roles);
            if (!result.Succeeded)
            {
                return new ErrorResponse(400, result.GetErrors());
            }

            return new SuccessResponse(Messages.AddRoleToUserSuccess, 201);
        }

        public async Task<IResponse> GetRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }

            var roles = await _userManager.GetRolesAsync(user);

            return new DataResponse<IList<string>>(roles, 200);
        }

        public async Task<IResponse> RenewToken(RenewTokenRequest token)
        {
            var result = await _tokenService.RenewToken(token);
            if (result.Token == null)
            {
                return new ErrorResponse(400, result.Message);
            }    

            return new DataResponse<Token>(result.Token, 200, result.Message);
        }

        public async Task<IResponse> UpdateRole(string userId, AddRolesToUserRequest request)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }
            
            if (!(await CheckRoleValid(request.Roles)))
            {
                return new ErrorResponse(400, Messages.InvalidRole);
            }

            var newRoles = request.Roles;
            var oldRoles = await _userManager.GetRolesAsync(user);
            var addRoles = newRoles.Where(r => !oldRoles.Contains(r)).ToList();
            var removeRoles = oldRoles.Where(r => !newRoles.Contains(r)).ToList();

            await _userManager.RemoveFromRolesAsync(user, removeRoles);
            await _userManager.AddToRolesAsync(user, addRoles);

            return new SuccessResponse(Messages.UpdatedSuccessfully, 200);
        }
        
        public async Task<IResponse> ConfirmEmail(ConfirmEmailRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }

            var result = await _userManager.ConfirmEmailAsync(user, request.Code);
            if (!result.Succeeded)
            {
                return new ErrorResponse(404, result.GetErrors());
            }

            return new SuccessResponse(Messages.ConfirmEmailSuccess, 200);
        }

        public async Task<IResponse> ResendConfirmEmail(ResendConfirmEmailRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound("User"));
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var resultCode = new ResendConfirmEmailResponse(code);

            return new DataResponse<ResendConfirmEmailResponse>(resultCode, 200, Messages.GetCodeConfirmEmailSuccess);
        }

        private async Task<bool> CheckAccess(string loggedUserId, string requestUserId)
        {
            var requestUser = await _userManager.FindByIdAsync(requestUserId);
            var loggedUser = await _userManager.FindByIdAsync(loggedUserId);

            if (requestUser == null || loggedUser == null)
            {
                return false;
            }

            if (requestUserId == loggedUserId)
            {
                return true;
            }

            return await _userManager.IsInRoleAsync(loggedUser, RoleName.Administrator);
        }

        private async Task<bool> CheckRoleValid(List<string> inputRoles)
        {
            var allRoles = await _roleManager.Roles.Select(x => x.Name).ToListAsync();
            if (inputRoles.Any(r => !allRoles.Contains(r)))
            {
                return false;
            }

            return true;
        }


        #endregion

        #region Post
        public async Task<IResponse> CreatePost(string loggedUserId , string requestUserId, CreatePostRequest request)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.BadRequest);
            }

            request.AuthorId = requestUserId;
            return await _postService.Create(request);
        }

        public async Task<IResponse> GetPostById(string loggedUserId, string requestUserId, Guid postId)
        {
            if (!await CheckAccessPost(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }    

            var post = await _unitOfWork.PostRepository.GetById(postId);
            if (post == null || post.AuthorId != requestUserId)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            return new DataResponse<GetPostResponse>(_mapper.Map<GetPostResponse>(post), 200);
        }

        public async Task<IResponse> GetPostByUser(string loggedUserId, string requestUserId, string? searchString, int pageSize, int pageNumber)
        {
            if (!await CheckAccessPost(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            Expression<Func<Post, bool>> filter;

            if (searchString != null)
            {
                filter = x => x.Content.Contains(searchString) && x.AuthorId == requestUserId && x.Status == 1;
            }   
            else
            {
                filter = x => x.AuthorId == requestUserId && x.Status == 1;
            }

            int totalItems = await _unitOfWork.PostRepository.Count(filter);
            int pageCount = (int)Math.Ceiling((double)totalItems / pageSize);

            if (pageNumber > pageCount && pageCount != 0)
            {
                return new ErrorResponse(400, Messages.OutOfPage);
            }    

            var posts = await _unitOfWork.PostRepository.GetPaged(pageSize, pageNumber, filter, x => x.CreatedAt);
            return new PagedResponse<List<GetPostResponse>>(_mapper.Map<List<GetPostResponse>>(posts), totalItems, 200);
        }

        public async Task<IResponse> UpdatePost(string loggedUserId, string requestUserId, Guid postId, UpdatePostRequest request)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            return await _postService.Update(requestUserId, postId, request);
        }

        public async Task<IResponse> DeletePost(string loggedUserId, string requestUserId, Guid postId)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            var post = await _unitOfWork.PostRepository.FindBy(p => p.Id == postId && p.AuthorId == requestUserId);
            if (post == null)
            {
                return new ErrorResponse(404, Messages.NotFound("Post"));
            }

            await _unitOfWork.PostRepository.Delete(postId);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new ErrorResponse(400, Messages.DeleteError);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);
        }

        private async Task<bool> CheckAccessPost(string loggedUserId, string requestUserId)
        {
            var requestUser = await _userManager.FindByIdAsync(requestUserId);
            var loggedUser = await _userManager.FindByIdAsync(loggedUserId);

            if (requestUser == null || loggedUser == null) return false;

            if (requestUserId == loggedUserId)
            {
                return true;
            }

            if (!await _userManager.IsInRoleAsync(loggedUser, RoleName.Administrator))
            {
                return true;
            }

            return await CheckFriend(loggedUserId, requestUserId);
        }

        #endregion

        #region Friendship

        public async Task<IResponse> AddFriend(string loggedUserId, string requestUserId, BaseFriendRequest request)
        {
            if (CheckCompareId(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.BadRequest);
            }    

            return await _friendshipService.AddFriendRequest(requestUserId, request);
        }

        public async Task<IResponse> UnFriend(string loggedUserId, string requestUserId, string targetUserId)
        {
            if (CheckCompareId(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.BadRequest);
            }

            return await _friendshipService.UnFriendRequest(requestUserId, targetUserId);
        }
        
        public async Task<IResponse> CancelRequest(string loggedUserId, string requestUserId, string targetUserId)
        {
            if (CheckCompareId(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.BadRequest);
            }

            return await _friendshipService.CancelRequest(requestUserId, targetUserId);
        }
        
        public async Task<IResponse> AcceptRequest(string loggedUserId, string requestUserId, string targetUserId)
        {
            if (CheckCompareId(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.BadRequest);
            }
            return await _friendshipService.AcceptRequest(requestUserId, targetUserId);
        }
        
        public async Task<IResponse> RefuseRequest(string loggedUserId, string requestUserId, string targetUserId)
        {
            if (CheckCompareId(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.BadRequest);
            }

            return await _friendshipService.RefuseRequest(requestUserId, targetUserId);
        }
        
        public async Task<IResponse> BlockFriend(string loggedUserId, string requestUserId, BaseFriendRequest request)
        {
            if (CheckCompareId(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.BadRequest);
            }

            return await _friendshipService.BlockFriend(requestUserId, request);
        }

        public async Task<IResponse> UnBlockFriend(string loggedUserId, string requestUserId, string targetUserId)
        {
            if (CheckCompareId(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.BadRequest);
            }

            return await _friendshipService.UnBlockFriend(requestUserId, targetUserId);
        }

        public async Task<IResponse> GetFriendshipByUser(string loggedUserId, string requestUserId, string? searchString, int pageSize, int pageNumber, FriendType type)
        {
            if (!await CheckOwnerOrAdminAsync(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.BadRequest);
            }

            return await _friendshipService.GetByUser(requestUserId, searchString, pageSize, pageNumber, type);
        }

        public async Task<IResponse> GetFriendshipById(string loggedUserId, string requestUserId, Guid id)
        {
            if (!await CheckOwnerOrAdminAsync(loggedUserId, requestUserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }    

            return await _friendshipService.GetById(requestUserId, id);
        }


        private bool CheckCompareId(string loggedUserId, string requestUserId) => loggedUserId == requestUserId;

        #endregion

        #region Message

        public async Task<IResponse> SendMessage(string loggedUserId, string requestUserId, SendMessageRequest request)
        {
            if (!CheckCompareId(loggedUserId, requestUserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            return await _messageService.SendMessage(requestUserId, request);

        }
        public async Task<IResponse> GetConversation(string loggedUserId, string requestUserId, string targetUserId, string? searchString, int pageSize, int pageNumber)
        {
            if (!CheckCompareId(loggedUserId, requestUserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            return await _messageService.GetByUser(requestUserId, targetUserId, searchString, pageSize, pageNumber);
        }
        public async Task<IResponse> GetMessageById(string loggedUserId, string requestUserId, Guid id)
        {
            if (!await CheckOwnerOrAdminAsync(loggedUserId, requestUserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }    

            return await _messageService.GetById(requestUserId, id);
        }
        public async Task<IResponse> DeleteMessage(string loggedUserId, string requestUserId, Guid id)
        {
            if (CheckCompareId(loggedUserId, requestUserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            return await _messageService.RevokeMessage(requestUserId, id);
        }

        private async Task<bool> CheckOwnerOrAdminAsync(string loggedUserId, string requestUserId)
        {
            var requestUser = await _userManager.FindByIdAsync(loggedUserId);
            var targetUser = await _userManager.FindByIdAsync(requestUserId);

            if (requestUser == null || targetUser == null)
            {
                return false;
            }

            // Is owner
            if (loggedUserId == requestUserId)
            {
                return true;
            }

            // Is admin
            return await _userManager.IsInRoleAsync(requestUser, RoleName.Administrator);
        }

        #endregion

        #region Notification

        public async Task<IResponse> GetNotifications(string loggedUserId, string requestUserId, string? searchString, int pageSize, int pageNumber)
        {
            if (!await CheckOwnerOrAdminAsync(loggedUserId, requestUserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            return await _notificationService.GetNotifications(requestUserId, searchString, pageSize, pageNumber);
        }

        public async Task<IResponse> GetNotificationsById(string loggedUserId, string requestUserId, Guid id)
        {
            if (!await CheckOwnerOrAdminAsync(loggedUserId, requestUserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            return await _notificationService.GetById(requestUserId, id);
        }

        public async Task<IResponse> SeenNotifications(string loggedUserId, string requestUserId, Guid id)
        {
            if (!await CheckOwnerOrAdminAsync(loggedUserId, requestUserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            return await _notificationService.SeenNotification(requestUserId, id);
        }

        #endregion

    
        private async Task<bool> CheckFriend(string userId1, string userId2)
        {
            var result = await _unitOfWork.FriendshipRepository.FindOneBy(x => x.RequestUserId == userId1 && x.TargetUserId == userId2 || x.RequestUserId == userId1 && x.TargetUserId == userId2);
            return result != null;
        }
    }
}

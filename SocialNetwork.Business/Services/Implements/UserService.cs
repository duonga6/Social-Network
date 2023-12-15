using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Friendship.Requests;
using SocialNetwork.Business.DTOs.Message.Requests;
using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.DTOs.Post.Responses;
using SocialNetwork.Business.DTOs.Token.Requests;
using SocialNetwork.Business.DTOs.User.Requests;
using SocialNetwork.Business.DTOs.User.Responses;
using SocialNetwork.Business.Helper;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using SocialNetwork.DataAccess.Utilities.Enum;
using SocialNetwork.DataAccess.Utilities.Roles;

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

        public UserService(IUnitOfWork unitOfWork,
                           IMapper mapper,
                           ILogger<UserService> logger,
                           UserManager<User> userManager,
                           ITokenService tokenService,
                           SignInManager<User> signInManager,
                           IPostService postService,
                           IFriendshipService friendshipService,
                           IMessageService messageService,
                           INotificationService notificationService) : base(unitOfWork, mapper, logger)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _postService = postService;
            _friendshipService = friendshipService;
            _messageService = messageService;
            _notificationService = notificationService;
        }

        #region Auth + User info

        public async Task<IResponse> GetAll()
        {
            var entities = await _unitOfWork.UserRepository.GetAll();
            return new DataResponse(_mapper.Map<List<GetUserResponse>>(entities), 200);
        }

        public async Task<IResponse> Register(RegistrationRequest request)
        {
            var checkExistUser = await _userManager.FindByEmailAsync(request.Email);
            if (checkExistUser != null)
            {
                return new ErrorResponse(400, Messages.EmailUsed);
            }

            var user = _mapper.Map<User>(request);
            var result = await _userManager.CreateAsync(user, user.Password);
            if (!result.Succeeded)
            {
                return new ErrorResponse(400, result.GetErrors());
            }

            return new DataResponse(_mapper.Map<GetUserResponse>(user), 201, Messages.RegistrationSuccessfully);
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


            return new DataResponse(token, 200, Messages.LoginSuccessfully);
        }

        public async Task<IResponse> ForgotPassword(ForgotPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("User"));
            }    

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            return new DataResponse(new ForgotPasswordCodeReponse(code), 200, Messages.GetCodeResetPassword);
        }

        public async Task<IResponse> ResetPassword(ResetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("User"));
            }    

            var result = await _userManager.ResetPasswordAsync(user, request.Code, request.Password);

            if (result.Succeeded)
            {
                var token = await _tokenService.CreateToken(user);
                return new DataResponse(token, 200, Messages.ResetPasswordSuccessfully);
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
                return new ErrorResponse(404, Messages.NotFound);
            }

            return new DataResponse(_mapper.Map<GetUserResponse>(user), 200);
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

            var userUpdated = await _unitOfWork.UserRepository.FindById(requestUserId);

            return new DataResponse(_mapper.Map<GetUserResponse>(userUpdated), 204, Messages.UpdatedSuccessfully);

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
                return new ErrorResponse(404, Messages.NotFound);
            }

            await _unitOfWork.UserRepository.Delete(user.Id);

            var result = await _unitOfWork.CompleteAsync();
            if (!result)
            {
                return new ErrorResponse(400, Messages.STWroong);
            }

            return new SuccessResponse(Messages.DeletedSuccessfully, 204);
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
                return new ErrorResponse(404, Messages.NotFounb("User"));
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
                return new ErrorResponse(404, Messages.NotFounb("User"));
            }

            var roles = await _userManager.GetRolesAsync(user);

            return new DataResponse(roles, 200);
        }

        public async Task<IResponse> RenewToken(RenewTokenRequest token)
        {
            var result = await _tokenService.RenewToken(token);
            if (result.Token == null)
            {
                return new ErrorResponse(400, result.Message);
            }    

            return new DataResponse(result.Token, 200, result.Message);
        }

        public async Task<IResponse> UpdateRole(string userId, AddRolesToUserRequest request)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFounb("User"));
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
                return new ErrorResponse(404, Messages.NotFounb("User"));
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
                return new ErrorResponse(404, Messages.NotFounb("User"));
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var resultCode = new ResendConfirmEmailResponse(code);

            return new DataResponse(resultCode, 200, Messages.GetCodeConfirmEmailSuccess);
        }

        private async Task<bool> CheckAccess(string loggedUserId, string requestUserId)
        {
            var requestUser = await _userManager.FindByIdAsync(requestUserId);
            var loggedUser = await _userManager.FindByEmailAsync(loggedUserId);

            if (requestUser == null || loggedUser == null)
            {
                return false;
            }
            
            if (loggedUserId != requestUserId && !await _userManager.IsInRoleAsync(loggedUser, RoleName.Administrator))
            {
                return false;
            }

            return true;
        }

        private async Task<bool> CheckRoleValid(List<string> inputRoles)
        {
            var allRoles = (await _unitOfWork.RoleRepository.GetAll()).Select(r => r.Name).ToList();
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
                return new ErrorResponse(404, Messages.NotFounb("Post"));
            }

            return new DataResponse(_mapper.Map<GetPostResponse>(post), 200);
        }

        public async Task<IResponse> GetPostByUser(string loggedUserId, string requestUserId)
        {
            if (!await CheckAccessPost(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            var result = await _unitOfWork.PostRepository.FindBy(x => x.AuthorId == requestUserId && x.Status == 1);
            return new DataResponse(_mapper.Map<List<GetPostResponse>>(result), 200);
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
                return new ErrorResponse(404, Messages.NotFounb("Post"));
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
            var requestUser = await _unitOfWork.UserRepository.FindById(requestUserId);
            var loggedUser = await _unitOfWork.UserRepository.FindById(loggedUserId);

            if (requestUser == null || loggedUser == null) return false;

            if (loggedUserId != requestUserId)
            {
                // Check admin:
                if (!await _userManager.IsInRoleAsync(loggedUser, RoleName.Administrator))
                {
                    return false;
                }    

                // Check friend:
                var isFriend = await _unitOfWork.FriendshipRepository
                    .FindOneBy(x => x.TargetUserId ==  loggedUserId && x.RequestUserId == requestUserId && x.FriendStatus == FriendshipStatus.Accepted
                                 || x.TargetUserId == requestUserId && x.RequestUserId == loggedUserId && x.FriendStatus == FriendshipStatus.Accepted
                );

                if (isFriend == null)
                {
                    return false;
                }    
            }    

            return true;
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

        public async Task<IResponse> GetFriendshipByUser(string loggedUserId, string requestUserId)
        {
            if (CheckCompareId(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.BadRequest);
            }

            return await _friendshipService.GetByUser(requestUserId);
        }

        private bool CheckCompareId(string loggedUserId, string requestUserId) => loggedUserId == requestUserId;

        #endregion

        #region Message

        public async Task<IResponse> SendMessage(string loggedUserId, string requestUserId, SendMessageRequest request)
        {
            if (CheckCompareId(loggedUserId, requestUserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            return await _messageService.SendMessage(requestUserId, request);

        }
        public async Task<IResponse> GetConversation(string loggedUserId, string requestUserId, string targetUserId)
        {
            if (CheckCompareId(loggedUserId, requestUserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            return await _messageService.GetAll(requestUserId, targetUserId);
        }
        public async Task<IResponse> DeleteMessage(string loggedUserId, string requestUserId, Guid id)
        {
            if (CheckCompareId(loggedUserId, requestUserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            return await _messageService.DeleteMessage(requestUserId, id);
        }

        private async Task<bool> CheckOwnerOrAdminAsync(string loggedUserId, string requestUserId)
        {
            var requestUser = await _unitOfWork.UserRepository.FindById(loggedUserId);
            var targetUser = await _unitOfWork.UserRepository.FindById(requestUserId);

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

        public async Task<IResponse> GetNotifications(string loggedUserId, string requestUserId)
        {
            if (!await CheckOwnerOrAdminAsync(loggedUserId, requestUserId))
            {
                return new ErrorResponse(400, Messages.BadRequest);
            }

            return await _notificationService.GetNotifications(requestUserId);
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

    }
}

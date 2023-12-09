using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Business.Constants;
using SocialNetwork.Business.DTOs.Friendship.Requests;
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
using SocialNetwork.DataAccess.Utilities.Roles;

namespace SocialNetwork.Business.Services.Implements
{
    public class UserService : BaseServices, IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        private readonly IPostService _postService;
        private readonly IFriendshipService _friendshipService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IPostService postService, IFriendshipService friendshipService) : base(unitOfWork, mapper)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _postService = postService;
            _friendshipService = friendshipService;
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

            return new DataResponse(_mapper.Map<GetUserResponse>(user), 201, Messages.RegistrationSucessfully);
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
                return new DataResponse(token, 200, Messages.ResetPasswordSuccesfully);
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


        #endregion

        #region Post
        public async Task<IResponse> CreatePost(string loggedUserId , string requestUserId, CreatePostRequest request)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            request.AuthorId = requestUserId;
            return await _postService.Create(request);
        }
        public async Task<IResponse> GetPostById(string loggedUserId, string requestUserId, Guid postId)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
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
            if (!await CheckAccess(loggedUserId, requestUserId))
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

        private async Task<bool> CheckAccess(string requestingUserId, string targetUserId)
        {
            var requestingUser = await _userManager.FindByIdAsync(requestingUserId);
            if (requestingUser == null || requestingUserId != targetUserId && !await _userManager.IsInRoleAsync(requestingUser, RoleName.Administrator))
            {
                return false;
            }
            return true;
        }

        #region Friendship

        public async Task<IResponse> AddFriend(string loggedUserId, string requestUserId, BaseFriendRequest request)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }    

            return await _friendshipService.AddFriendRequest(requestUserId, request);
        }

        public async Task<IResponse> UnFriend(string loggedUserId, string requestUserId, string targetUserId)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            return await _friendshipService.UnFriendRequest(requestUserId, targetUserId);
        }
        
        public async Task<IResponse> CancelRequest(string loggedUserId, string requestUserId, string targetUserId)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            return await _friendshipService.CancelRequest(requestUserId, targetUserId);
        }
        
        public async Task<IResponse> AcceptRequest(string loggedUserId, string requestUserId, string targetUserId)
        {
            return await _friendshipService.AcceptRequest(requestUserId, targetUserId);
        }
        
        public async Task<IResponse> RefuseRequest(string loggedUserId, string requestUserId, string targetUserId)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            return await _friendshipService.RefuseRequest(requestUserId, targetUserId);
        }
        
        public async Task<IResponse> BlockFriend(string loggedUserId, string requestUserId, BaseFriendRequest request)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            return await _friendshipService.BlockFriend(requestUserId, request);
        }

        public async Task<IResponse> UnBlockFriend(string loggedUserId, string requestUserId, string targetUserId)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            return await _friendshipService.UnBlockFriend(requestUserId, targetUserId);
        }

        public async Task<IResponse> GetFriendshipByUser(string loggedUserId, string requestUserId)
        {
            if (!await CheckAccess(loggedUserId, requestUserId))
            {
                return new ErrorResponse(403, Messages.Forbidden);
            }

            return await _friendshipService.GetByUser(requestUserId);
        }

        #endregion
    }
}

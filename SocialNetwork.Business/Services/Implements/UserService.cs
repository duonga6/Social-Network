using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Business.Constants;
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

namespace SocialNetwork.Business.Services.Implements
{
    public class UserService : BaseServices, IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPostService _postService;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IPostService postService) : base(unitOfWork, mapper)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _postService = postService;
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
                return new ErrorResponse(400, Messages.AddError);
            }

            return new DataResponse(_mapper.Map<GetUserResponse>(user), 201, Messages.RegistrationSucessfully);
        }

        public async Task<IResponse> GetById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ErrorResponse(404, Messages.NotFound);
            }

            return new DataResponse(_mapper.Map<GetUserResponse>(user), 200);
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
                return new ErrorResponse(400, Messages.IncorrectEP);
            }

            var token = await _tokenService.CreateToken(user);


            return new DataResponse(token, 200, Messages.LoginSuccessfully);
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

        public async Task<IResponse> CreatePost(string userId, CreatePostRequest request)
        {
            request.AuthorId = userId;
            return await _postService.Create(request);
        }

        public async Task<IResponse> DeletePost(string userId, Guid postId)
        {
            var post = await _unitOfWork.PostRepository.FindBy(p => p.Id == postId && p.AuthorId == userId);
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

        public async Task<IResponse> GetPostById(string userId, Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetById(postId);
            if (post == null || post.AuthorId != userId)
            {
                return new ErrorResponse(404, Messages.NotFounb("Post"));
            }

            return new DataResponse(_mapper.Map<GetPostResponse>(post), 200);
        }

        public async Task<IResponse> GetPostByUser(string userId)
        {
            var result = await _unitOfWork.PostRepository.FindBy(x => x.AuthorId == userId && x.Status == 1);
            return new DataResponse(_mapper.Map<List<GetPostResponse>>(result), 200);
        }

        public async Task<IResponse> UpdatePost(string userId, Guid postId, UpdatePostRequest request)
        {
            return await _postService.Update(postId, request);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Business.DTOs.Token;
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
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager) : base(unitOfWork, mapper)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IResponse> Register(RegistrationRequest request)
        {
            var checkExistUser = await _userManager.FindByEmailAsync(request.Email);
            if (checkExistUser != null)
            {
                return new ErrorResponse(400, "Email is used");
            }

            var user = _mapper.Map<User>(request);
            var result = await _userManager.CreateAsync(user, user.Password);
            if (!result.Succeeded)
            {
                return new ErrorResponse(400, "Create account errors");
            }

            return new DataResponse(_mapper.Map<GetUserResponse>(user), 201, "Registration successfully");
        }

        public async Task<IResponse> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return new ErrorResponse(404, "User not found");
            }

            return new DataResponse(_mapper.Map<GetUserResponse>(user), 200);
        }

        public async Task<IResponse> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ErrorResponse(404, "Email or password is not correct");
            }    

            var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!signInResult.Succeeded)
            {
                return new ErrorResponse(400, "Email or password is not correct");
            }

            var token = await _tokenService.CreateToken(user);


            return new DataResponse(token, 200, "Login successfully");
        }

        public async Task<IResponse> AddRoles(AddRolesToUserRequest request)
        {
            if (request.Roles == null || request.Roles.Count == 0)
            {
                return new ErrorResponse(400, "Roles is empty");
            }

            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return new ErrorResponse(404, "User not found");
            }

            var allRoles = (await _unitOfWork.RoleRepository.GetAll()).Select(r => r.Name).ToList();
            if (request.Roles.Any(r => !allRoles.Contains(r)))
            {
                return new ErrorResponse(400, "Role item is not valid");
            }    

            var result = await _userManager.AddToRolesAsync(user, request.Roles);
            if (!result.Succeeded)
            {
                return new ErrorResponse(400, result.GetErrors());
            }

            return new SuccessResponse("Add role successfully", 201);
        }

        public async Task<IResponse> GetRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return new ErrorResponse(404, "User not found");
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
    }
}

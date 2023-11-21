using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.DTOs.Token;
using SocialNetwork.Business.DTOs.Token.Requests;
using SocialNetwork.Business.DTOs.User.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IResponse> Register(RegistrationRequest request)
        {
            return await _userService.Register(request);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IResponse> Login(LoginRequest request)
        {
            return await _userService.Login(request);
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<IResponse> AddRole(AddRolesToUserRequest request)
        {
            return await _userService.AddRoles(request);
        }

        [HttpGet]
        [Route("GetRoles")]
        public async Task<IResponse> GetRole(string id)
        {
            return await _userService.GetRoles(id);
        }

        [HttpPost]
        [Route("RenewToken")]
        public async Task<IResponse> RenewToken(RenewTokenRequest token)
        {
            return await _userService.RenewToken(token);
        }
    }
}

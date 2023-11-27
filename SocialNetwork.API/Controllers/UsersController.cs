using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.DTOs.Token.Requests;
using SocialNetwork.Business.DTOs.User.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
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

        [HttpGet]
        [Route("{Id}")]
        public async Task<IResponse> GetById(string Id)
        {
            return await _userService.GetById(Id);
        }

        [HttpPost]
        [Route("{Id}/Roles")]
        public async Task<IResponse> AddRole(string Id, AddRolesToUserRequest request)
        {
            return await _userService.AddRoles(Id, request);
        }

        [HttpGet]
        [Route("{Id}/Roles")]
        public async Task<IResponse> GetRole(string Id)
        {
            return await _userService.GetRoles(Id);
        }

        [HttpPost]
        [Route("RenewToken")]
        public async Task<IResponse> RenewToken(RenewTokenRequest token)
        {
            return await _userService.RenewToken(token);
        }

        [HttpPut]
        [Route("{Id}/Roles")]
        public async Task<IResponse> UpdateRoles(string Id, AddRolesToUserRequest request)
        {
            return await _userService.UpdateRole(Id, request);
        }

        [HttpPost]
        [Route("{Id}/Posts")]
        public async Task<IResponse> CreatePost(string Id, CreatePostRequest request)
        {
            return await _userService.CreatePost(Id, request);
        }

        [HttpDelete]
        [Route("{Id}/Posts/{postId:guid}")]
        public async Task<IResponse> DeletePost(string Id, Guid postId)
        {
            return await _userService.DeletePost(Id, postId);
        }

        [HttpGet]
        [Route("{Id}/Posts/{postId:guid}")]
        public async Task<IResponse> GetPostById(string Id, Guid postId)
        {
            return await _userService.GetPostById(Id, postId);
        }

        [HttpGet("{Id}/Posts")]
        public async Task<IResponse> GetPostByUser(string Id)
        {
            return await _userService.GetPostByUser(Id);
        }


    }
}

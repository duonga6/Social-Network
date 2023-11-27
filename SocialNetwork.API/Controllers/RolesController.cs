using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.DTOs.Role.Request;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.API.Controllers
{
    public class RolesController : BaseController
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            return await _roleService.GetAll();
        }

        [HttpPost]
        public async Task<IResponse> Create(CreateRoleRequest request)
        {
            return await _roleService.Add(request);
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IResponse> Update(string Id, UpdateRoleRequest request)
        {
            return await _roleService.Update(Id, request);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IResponse> Delete(string Id)
        {
            return await _roleService.Delete(Id);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IResponse> GetById(string Id)
        {
            return await _roleService.GetById(Id);
        }
    }
}

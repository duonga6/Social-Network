using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.DTOs.Role.Request;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.API.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
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
        public async Task<IResponse> Update(UpdateRoleRequest request)
        {
            return await _roleService.Update(request);
        }

        [HttpDelete]
        public async Task<IResponse> Delete(DeleteRoleRequest request)
        {
            return await _roleService.Delete(request);
        }
    }
}

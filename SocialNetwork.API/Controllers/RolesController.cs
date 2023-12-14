using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.DTOs.Role.Request;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Utilities.Roles;

namespace SocialNetwork.API.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class RolesController : BaseController
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Get all role
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            return await _roleService.GetAll();
        }

        /// <summary>
        /// Create role
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponse> Create(CreateRoleRequest request)
        {
            return await _roleService.Add(request);
        }

        /// <summary>
        /// Update role
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{Id}")]
        public async Task<IResponse> Update(string Id, UpdateRoleRequest request)
        {
            return await _roleService.Update(Id, request);
        }

        /// <summary>
        /// Delete role
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IResponse> Delete(string Id)
        {
            return await _roleService.Delete(Id);
        }

        /// <summary>
        /// Get role by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Id}")]
        public async Task<IResponse> GetById(string Id)
        {
            return await _roleService.GetById(Id);
        }
    }
}

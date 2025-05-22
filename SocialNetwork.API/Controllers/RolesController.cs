using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Utilities;

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
        public async Task<IActionResult> GetAll()
        {
            return ResponseModel(await _roleService.GetAll());
        }

        /// <summary>
        /// Create role
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleRequest request)
        {
            return ResponseModel(await _roleService.Add(request));
        }

        /// <summary>
        /// Update role
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> Update(string Id, UpdateRoleRequest request)
        {
            return ResponseModel(await _roleService.Update(Id, request));
        }

        /// <summary>
        /// Delete role
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            return ResponseModel(await _roleService.Delete(Id));
        }

        /// <summary>
        /// Get role by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            return ResponseModel(await _roleService.GetById(Id));
        }
    }
}

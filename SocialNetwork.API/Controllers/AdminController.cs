using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Abstract;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="searchString"></param>
        /// <param name="orderBy"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        [HttpGet("Users")]
        [ProducesResponseType(typeof(PagedResponse<List<GetUserByAdminResponse>>), 200)]
        public async Task<IActionResult> GetUser(int pageSize, int pageNumber, string? searchString, OrderByEnum orderBy, bool isDesc)
        {
            return ResponseModel(await _adminService.GetUser(pageSize, pageNumber, searchString, orderBy, isDesc));
        }

        /// <summary>
        /// Get post
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpGet("Posts")]
        [ProducesResponseType(typeof(PagedResponse<List<GetPostByAdminResponse>>), 200)]
        public async Task<IActionResult> GetPost(int pageSize, int pageNumber, string? searchString)
        {
            return ResponseModel(await _adminService.GetPost(pageSize, pageNumber, searchString));
        }
    }
}

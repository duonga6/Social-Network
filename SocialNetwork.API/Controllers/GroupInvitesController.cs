using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Abstract;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class GroupInvitesController : BaseController
    {
        private readonly IGroupInviteService _groupInviteService;

        public GroupInvitesController(IGroupInviteService groupInviteService)
        {
            _groupInviteService = groupInviteService;
        }

        /// <summary>
        /// Get invite request of group which is not admin accept
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<List<GetGroupInviteResponse>>), 200)]
        public async Task<IActionResult> Get([FromQuery] string? searchString, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber, [FromQuery, Required] Guid groupId)
        {
            return ResponseModel(await _groupInviteService.GetByGroup(UserId, searchString, pageSize, pageNumber, groupId));
        }

        /// <summary>
        /// Create group invite
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DataResponse<GetGroupInviteResponse>), 201)]
        public async Task<IActionResult> Create([FromBody] CreateGroupInviteRequest request)
        {
            return ResponseModel(await _groupInviteService.Create(UserId, request));
        }

        /// <summary>
        /// Refuse or cancle request invite
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return ResponseModel(await _groupInviteService.Delete(UserId, Id));
        }

        /// <summary>
        /// Delete request join by groupId
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> DeleteByGroup([FromQuery, Required] Guid groupId)
        {
            return ResponseModel(await _groupInviteService.DeleteByGroup(UserId, groupId));
        }

        /// <summary>
        /// Accept user invite group
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetGroupMemberResponse>), 200)]
        public async Task<IActionResult> AcceptInvite(Guid Id)
        {
            return ResponseModel(await _groupInviteService.AcceptRequest(UserId, Id));
        }
    
        /// <summary>
        /// Get user invite by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetGroupMemberResponse>), 200)]
        public async Task<IActionResult> GetById(Guid Id)
        {
            return ResponseModel(await _groupInviteService.GetById(UserId, Id));
        }

        /// <summary>
        /// Get user invite by userId and groupId
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{groupId}/{userId}")]
        public async Task<IActionResult> GetByUserIdAndGrId(Guid groupId, string userId)
        {
            return ResponseModel(await _groupInviteService.GetById(UserId, userId, groupId));
        }
        
        /// <summary>
        /// Get group invite by cursor
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="pageSize"></param>
        /// <param name="cursor"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpGet("Cursor")]
        [ProducesResponseType(typeof(CursorResponse<List<GetGroupInviteResponse>>), 200)]
        public async Task<IActionResult> GetCursor([FromQuery, Required] Guid groupId, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, DateTime? cursor, string? searchString)
        {
            return ResponseModel(await _groupInviteService.GetCursor(UserId, groupId, pageSize, cursor, searchString));
        }
    }
}

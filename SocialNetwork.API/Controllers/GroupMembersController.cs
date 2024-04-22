using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Abstract;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class GroupMembersController : BaseController
    {
        private readonly IGroupMemberService _groupMemberService;

        public GroupMembersController(IGroupMemberService groupMemberService)
        {
            _groupMemberService = groupMemberService;
        }

        /// <summary>
        /// Get member of group
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="searchString"></param>
        /// <param name="groupId"></param>
        /// <param name="memberType">0 - All; 1 - admin only; 2 - super admin only; 3 - normal member only; default: 0</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<List<GetGroupMemberResponse>>), 200)]
        public async Task<IActionResult> GetAll([FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber,[FromQuery] string? searchString, [Required, FromQuery] Guid groupId, [FromQuery] MemberType memberType = MemberType.ALL)
        {
            return ResponseModel(await _groupMemberService.GetAll(UserId, pageSize, pageNumber, searchString, groupId, memberType));
        }

        /// <summary>
        /// Get member of group by cursor
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="cursor"></param>
        /// <param name="searchString"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet("Cursor")]
        [ProducesResponseType(typeof(CursorResponse<List<GetGroupMemberResponse>>), 200)]
        public async Task<IActionResult> GetCursor([FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery] DateTime? cursor, [FromQuery] string? searchString,[FromQuery, Required] Guid groupId)
        {
            return ResponseModel(await _groupMemberService.GetCursor(UserId, pageSize, cursor, searchString, groupId));
        }

        /// <summary>
        /// Invite a user to group
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DataResponse<GetGroupInviteResponse>), 201)]
        public async Task<IActionResult> InviteMember([FromBody] CreateGroupMemberRequest request)
        {
            return ResponseModel(await _groupMemberService.InviteUser(UserId, request));
        }

        /// <summary>
        /// Delete member
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> DeleteMember(Guid Id)
        {
            return ResponseModel(await _groupMemberService.Delete(UserId, Id));
        }

        /// <summary>
        /// Delete member
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> DeleteMember([FromQuery, Required] string userId,[Required, FromQuery] Guid groupId)
        {
            return ResponseModel(await _groupMemberService.Delete(UserId, groupId, userId));
        }
        
        /// <summary>
        /// Get member by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetGroupMemberResponse>), 200)]
        public async Task<IActionResult> GetById(Guid Id)
        {
            return ResponseModel(await _groupMemberService.GetById(UserId, Id));
        }

        /// <summary>
        /// Get member by userId and groupId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet("{groupId}/{userId}")]
        [ProducesResponseType(typeof(DataResponse<GetGroupMemberResponse>), 200)]
        public async Task<IActionResult> GetById(string userId, Guid groupId)
        {
            return ResponseModel(await _groupMemberService.GetById(UserId, groupId, userId));
        }
        
        /// <summary>
        /// Create admin by userId and groupId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Admin")]
        [ProducesResponseType(typeof(DataResponse<GetGroupMemberResponse>), 200)]
        public async Task<IActionResult> CreateAdmin(CreateGroupAdminRequest request)
        {
            return ResponseModel(await _groupMemberService.CreateAdmin(UserId, request));
        }

        /// <summary>
        /// Create admin by memberId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Admin")]
        [ProducesResponseType(typeof(DataResponse<GetGroupMemberResponse>), 200)]
        public async Task<IActionResult> CreateAdmin(Guid Id)
        {
            return ResponseModel(await _groupMemberService.CreateAdmin(UserId, Id));
        }

        /// <summary>
        /// Delete admin by userId and groupId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpDelete("Admin/{groupId}/{userId}")]
        [ProducesResponseType(typeof(DataResponse<GetGroupMemberResponse>), 200)]
        public async Task<IActionResult> DeleteAdmin(string userId, Guid groupId)
        {
            return ResponseModel(await _groupMemberService.DeleteAdmin(UserId, groupId, userId));
        }

        /// <summary>
        /// Delete admin by memberId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Admin")]
        [ProducesResponseType(typeof(DataResponse<GetGroupMemberResponse>), 200)]
        public async Task<IActionResult> DeleteAdmin(Guid Id)
        {
            return ResponseModel(await _groupMemberService.DeleteAdmin(UserId, Id));
        }
    }
}

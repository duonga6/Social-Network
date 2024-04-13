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
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<List<GetGroupMemberResponse>>), 200)]
        public async Task<IResponse> GetAll([FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber,[FromQuery] string? searchString,[Required, FromQuery] Guid groupId)
        {
            return await _groupMemberService.GetAll(UserId, pageSize, pageNumber, searchString, groupId);
        }

        /// <summary>
        /// Invite a user to group
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DataResponse<GetGroupInviteResponse>), 201)]
        public async Task<IResponse> InviteMember([FromBody] CreateGroupMemberRequest request)
        {
            return await _groupMemberService.InviteUser(UserId, request);
        }

        /// <summary>
        /// Delete member
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> DeleteMember(Guid Id)
        {
            return await _groupMemberService.Delete(UserId, Id);
        }

        /// <summary>
        /// Delete member
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> DeleteMember([FromQuery, Required] string userId,[Required, FromQuery] Guid groupId)
        {
            return await _groupMemberService.Delete(UserId, groupId, userId);
        }
    }
}

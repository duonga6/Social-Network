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
        public async Task<IResponse> Get([FromQuery] string? searchString, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber, [FromQuery, Required] Guid groupId)
        {
            return await _groupInviteService.GetByGroup(UserId, searchString, pageSize, pageNumber, groupId);
        }

        /// <summary>
        /// Create group invite
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DataResponse<GetGroupInviteResponse>), 201)]
        public async Task<IResponse> Create([FromBody] CreateGroupInviteRequest request)
        {
            return await _groupInviteService.Create(UserId, request);
        }

        /// <summary>
        /// Refuse or cancle request invite
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> Delete(Guid Id)
        {
            return await _groupInviteService.Delete(UserId, Id);
        }

        /// <summary>
        /// Accept user invite group
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetGroupMemberResponse>), 200)]
        public async Task<IResponse> AcceptInvite(Guid Id)
        {
            return await _groupInviteService.AcceptRequest(UserId, Id);
        }
    }
}

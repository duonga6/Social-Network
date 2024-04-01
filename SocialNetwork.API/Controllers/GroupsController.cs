using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.Groups.Request;
using SocialNetwork.Business.DTOs.Groups.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class GroupsController : BaseController
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        /// <summary>
        /// Get list group
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<List<GetGroupResponse>>), 200)]
        public async Task<IResponse> Get([FromQuery]string? searchString,[FromQuery, Required, Range(0, int.MaxValue)] int pageSize,[FromQuery, Required, Range(0, int.MaxValue)] int pageNumber)
        {
            return await _groupService.Get(UserId, searchString, pageSize, pageNumber);
        }

        /// <summary>
        /// Create group
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DataResponse<GetGroupResponse>), 200)]
        public async Task<IResponse> Create([FromBody] CreateGroupRequest request)
        {
            return await _groupService.Create(UserId, request);
        }

        /// <summary>
        /// Get group by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetGroupResponse>), 200)]
        public async Task<IResponse> GetById([FromRoute] Guid Id)
        {
            return await _groupService.GetById(UserId, Id);
        }

        /// <summary>
        /// Update group
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetGroupResponse>), 200)]
        public async Task<IResponse> Update([FromRoute] Guid Id, [FromBody] UpdateGroupRequest request)
        {
            return await _groupService.Update(UserId, Id, request);
        }

        /// <summary>
        /// Delete group
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> Delete([FromRoute] Guid Id)
        {
            return await _groupService.Delete(UserId, Id);
        }
    }
}

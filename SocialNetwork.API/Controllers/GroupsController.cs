using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
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
        /// <param name="type">Type group get 0: all group - 1: joined group - 2: group managed by me - 3: Both joined and managed</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<List<GetGroupResponse>>), 200)]
        public async Task<IActionResult> Get([FromQuery]string? searchString,[FromQuery, Required, Range(1, int.MaxValue)] int pageSize,[FromQuery, Required, Range(1, int.MaxValue)] int pageNumber,[Required] GroupType type)
        {
            return ResponseModel(await _groupService.Get(UserId, searchString, pageSize, pageNumber, type));
        }

        /// <summary>
        /// Create group
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DataResponse<GetGroupResponse>), 200)]
        public async Task<IActionResult> Create([FromBody] CreateGroupRequest request)
        {
            return ResponseModel(await _groupService.Create(UserId, request));
        }

        /// <summary>
        /// Get group by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetGroupResponse>), 200)]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            return ResponseModel(await _groupService.GetById(UserId, Id));
        }

        /// <summary>
        /// Update group
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetGroupResponse>), 200)]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] UpdateGroupRequest request)
        {
            return ResponseModel(await _groupService.Update(UserId, Id, request));
        }

        /// <summary>
        /// Delete group
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            return ResponseModel(await _groupService.Delete(UserId, Id));
        }


        [HttpGet("{Id}/Medias")]
        public async Task<IResponse> GetMedia([FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber, Guid Id)
        {
            return await _groupService.GetMedia(UserId, Id, pageSize, pageNumber);
        }

        /// <summary>
        /// Get group post feed
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        [HttpGet("Feed")]
        [ProducesResponseType(typeof(CursorResponse<List<GetPostResponse>>), 200)]
        public async Task<IActionResult> GetPostFeed([FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery] DateTime? cursor)
        {
            return ResponseModel(await _groupService.GetFeed(UserId, pageSize, cursor));
        }

        /// <summary>
        /// Get group's post
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Posts")]
        [ProducesResponseType(typeof(PagedResponse<List<GetPostResponse>>), 200)]
        public async Task<IActionResult> GetGroupPost([FromQuery] string? searchString, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber, Guid Id)
        {
            return ResponseModel(await _groupService.GetPost(UserId, Id, pageSize, pageNumber, searchString));
        }

        /// <summary>
        /// Get group's post by cursor
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="cursor"></param>
        /// <param name="pageSize"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Posts/Cursor")]
        [ProducesResponseType(typeof(CursorResponse<List<GetPostResponse>>), 200)]
        public async Task<IActionResult> GetGroupPost([FromQuery] string? searchString, [FromQuery] DateTime? cursor, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, Guid Id)
        {
            return ResponseModel(await _groupService.GetPost(UserId, Id, pageSize, cursor, searchString));
        }

        /// <summary>
        /// Get stats of group
        /// </summary>
        /// <returns></returns>
        [HttpGet("Stats")]
        [ProducesResponseType(typeof(DataResponse<StatsGroupResponse>), 200)]
        public async Task<IActionResult> GetStats()
        {
            return ResponseModel(await _groupService.StatsGroupResponse(UserId));
        }
    }
}

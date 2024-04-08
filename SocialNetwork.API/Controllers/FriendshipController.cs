using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
using System.ComponentModel.DataAnnotations;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class FriendshipController : BaseController
    {
        private readonly IFriendshipService _friendshipService;

        public FriendshipController(IFriendshipService friendshipService)
        {
            _friendshipService = friendshipService;
        }

        /// <summary>
        /// Get all friendship of current user
        /// </summary>
        /// <param name="pageSize">Item per page</param>
        /// <param name="pageNumber">Current page</param>
        /// <param name="searchString">Search by name</param>
        /// <param name="type">Type friend to get 0: all, 1: pending from me, 2: pending from other, 3: accepted, 4: blocked</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<List<GetFriendshipResponse>>), 200)]
        public async Task<IResponse> Get([FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber,[FromQuery] string? searchString,[FromQuery, Required] FriendType type)
        {
            return await _friendshipService.GetByUser(UserId, searchString, pageSize, pageNumber, type);
        }

        /// <summary>
        /// Get friendship by Id of user
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetFriendshipResponse>), 200)]
        public async Task<IResponse> GetById(Guid Id)
        {
            return await _friendshipService.GetById(UserId, Id);
        }

        /// <summary>
        /// Send friend invitations
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("AddFriend")]
        [ProducesResponseType(typeof(DataResponse<GetFriendshipResponse>), 200)]
        public async Task<IResponse> SendRequest([FromBody] BaseFriendRequest request)
        {
            return await _friendshipService.AddFriendRequest(UserId, request);
        }

        /// <summary>
        /// Unfriend
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("UnFriend/{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> UnFriend(Guid Id)
        {
            return await _friendshipService.UnFriendRequest(UserId, Id);
        }

        /// <summary>
        /// Cancel friend request
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("CancelAddFriendRequest/{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> CancelRequest(Guid Id)
        {
            return await _friendshipService.CancelRequest(UserId, Id);
        }

        /// <summary>
        /// Accept friend request
        /// </summary>
        /// <param name="Id">Id of friendship</param>
        /// <returns></returns>
        [HttpPut("AcceptFriend/{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> AcceptFriend(Guid Id)
        {
            return await _friendshipService.AcceptRequest(UserId, Id);
        }

        /// <summary>
        /// Refuse friend request
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("RefuseFriend/{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> RefuseFriend(Guid Id)
        {
            return await _friendshipService.RefuseRequest(UserId, Id);
        }

        /// <summary>
        /// Block friend / user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("BlockFriend")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> BlockFriend([FromBody] BaseFriendRequest request)
        {
            return await _friendshipService.BlockFriend(UserId, request);
        }

        /// <summary>
        /// Unblock friend
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("UnblockFriend/{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> UnblockFriend(Guid Id)
        {
            return await _friendshipService.UnBlockFriend(UserId, Id);
        }

        /// <summary>
        /// Get friendship status with target user
        /// </summary>
        /// <param name="targetUserId"></param>
        /// <returns></returns>
        [HttpGet("Info/{targetUserId}")]
        [ProducesResponseType(typeof(DataResponse<GetFriendshipResponse>), 200)]
        public async Task<IResponse> GetInfo(string targetUserId)
        {
            return await _friendshipService.GetInfo(UserId, targetUserId);
        }

        /// <summary>
        /// Get suggestion friend
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [HttpGet("SuggestionFriend")]
        [ProducesResponseType(typeof(PagedResponse<List<GetUserResponse>>), 200)]
        public async Task<IResponse> GetSuggestionFriend([FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return await _friendshipService.GetSuggestFriend(UserId, pageSize, pageNumber);
        }
    }
}

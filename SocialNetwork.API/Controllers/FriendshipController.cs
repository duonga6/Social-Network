using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.DTOs.Friendship.Requests;
using SocialNetwork.Business.DTOs.Friendship.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using System.ComponentModel.DataAnnotations;

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
        /// <param name="targetUserId"></param>
        /// <returns></returns>
        [HttpDelete("UnFriend/{targetUserId}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> UnFriend(string targetUserId)
        {
            return await _friendshipService.UnFriendRequest(UserId, targetUserId);
        }

        /// <summary>
        /// Cancel friend request
        /// </summary>
        /// <param name="targetUserId"></param>
        /// <returns></returns>
        [HttpDelete("CancelAddFriendRequest/{targetUserId}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> CancelRequest(string targetUserId)
        {
            return await _friendshipService.CancelRequest(UserId, targetUserId);
        }

        /// <summary>
        /// Accept friend request
        /// </summary>
        /// <param name="targetUserId"></param>
        /// <returns></returns>
        [HttpPost("AcceptFriend/{targetUserId}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> AcceptFriend(string targetUserId)
        {
            return await _friendshipService.AcceptRequest(UserId, targetUserId);
        }

        /// <summary>
        /// Refuse friend request
        /// </summary>
        /// <param name="targetUserId"></param>
        /// <returns></returns>
        [HttpDelete("RefuseFriend/{targetUserId}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> RefuseFriend(string targetUserId)
        {
            return await _friendshipService.RefuseRequest(UserId, targetUserId);
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
        /// <param name="targetUserId"></param>
        /// <returns></returns>
        [HttpPut("UnblockFriend/{targetUserId}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> UnblockFriend(string targetUserId)
        {
            return await _friendshipService.UnBlockFriend(UserId, targetUserId);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.DTOs.Friendship.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Interfaces;

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
        /// Get all friendship (admin)
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IResponse> GetAll()
        {
            return await _friendshipService.GetByUser(UserId);
        }

        /// <summary>
        /// Send friend invitations
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("AddFriend")]
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
        public async Task<IResponse> CancelRequest(string targetUserId)
        {
            return await _friendshipService.CancelRequest(UserId, targetUserId);
        }

        /// <summary>
        /// Accept friend request
        /// </summary>
        /// <param name="targetUserId"></param>
        /// <returns></returns>
        [HttpPut("AcceptFriend/{targetUserId}")]
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
        public async Task<IResponse> UnblockFriend(string targetUserId)
        {
            return await _friendshipService.UnBlockFriend(UserId, targetUserId);
        }
    }
}

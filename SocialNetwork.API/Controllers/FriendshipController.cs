using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.DTOs.Friendship.Requests;
using SocialNetwork.Business.Services.Implements;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class FriendshipController : BaseController
    {
        private readonly FriendshipService _friendshipService;

        public FriendshipController(FriendshipService friendshipService)
        {
            _friendshipService = friendshipService;
        }

        [HttpPost("AddFriend")]
        public async Task<IResponse> SendRequest([FromBody] BaseFriendRequest request)
        {
            return await _friendshipService.AddFriendRequest(UserId, request);
        }

        [HttpDelete("UnFriend/{targetUserId}")]
        public async Task<IResponse> UnFriend(string targetUserId)
        {
            return await _friendshipService.UnFriendRequest(UserId, targetUserId);
        }

        [HttpDelete("CancelAddFriendRequest/{targetUserId}")]
        public async Task<IResponse> CancelRequest(string targetUserId)
        {
            return await _friendshipService.CancelRequest(UserId, targetUserId);
        }

        [HttpPut("AcceptFriend/{targetUserId}")]
        public async Task<IResponse> AcceptFriend(string targetUserId)
        {
            return await _friendshipService.AcceptRequest(UserId, targetUserId);
        }

        [HttpDelete("RefuseFriend/{targetUserId}")]
        public async Task<IResponse> RefuseFriend(string targetUserId)
        {
            return await _friendshipService.RefuseRequest(UserId, targetUserId);
        }

        [HttpPost("BlockFriend")]
        public async Task<IResponse> BlockFriend([FromBody] BaseFriendRequest request)
        {
            return await _friendshipService.BlockFriend(UserId, request);
        }

        [HttpDelete("UnblockFriend/{targetUserId}")]
        public async Task<IResponse> UnblockFriend(string targetUserId)
        {
            return await _friendshipService.UnBlockFriend(UserId, targetUserId);
        }
    }
}

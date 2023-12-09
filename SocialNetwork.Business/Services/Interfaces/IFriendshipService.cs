using SocialNetwork.Business.DTOs.Friendship.Requests;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IFriendshipService
    {
        Task<IResponse> AddFriendRequest(string requestUserId, BaseFriendRequest request);
        Task<IResponse> UnFriendRequest(string requestUserId, string targetUserId);
        Task<IResponse> CancelRequest(string requestUserId, string targetUserId);
        Task<IResponse> AcceptRequest(string requestUserId, string targetUserId);
        Task<IResponse> RefuseRequest(string requestUserId, string targetUserId);
        Task<IResponse> BlockFriend(string requestUserId, BaseFriendRequest request);
        Task<IResponse> UnBlockFriend(string requestUserId, string targetUserId);
        Task<IResponse> GetByUser(string userId);
    }
}

using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.Business.DTOs.Requests;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IFriendshipService
    {
        Task<IResponse> AddFriendRequest(string requestUserId, BaseFriendRequest request);
        Task<IResponse> UnFriendRequest(string requestUserId, Guid id);
        Task<IResponse> CancelRequest(string requestUserId, Guid id);
        Task<IResponse> AcceptRequest(string requestUserId, Guid id);
        Task<IResponse> RefuseRequest(string requestUserId, Guid id);
        Task<IResponse> BlockFriend(string requestUserId, BaseFriendRequest request);
        Task<IResponse> UnBlockFriend(string requestUserId, Guid id);
        Task<IResponse> GetByUser(string requestUserId, string? searchString, int pageSize, int pageNumber, FriendType type);
        Task<IResponse> GetById(string requestUserId, Guid id);
        Task<IResponse> GetInfo(string requestUserId, string targetUserId);
        Task<IResponse> GetSuggestFriend(string requestUserId, int pageSize, int pageNumber);
        Task<bool> IsFriend(string userId1, string userId2);

        Task<IResponse> GetFriendActive(string requestId);
    }
}

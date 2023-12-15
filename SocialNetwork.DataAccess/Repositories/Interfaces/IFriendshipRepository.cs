using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IFriendshipRepository : IGenericRepository<Friendship>
    {
        Task<bool> IsFriend(string requestUserId, string targetUserId);
        Task<ICollection<Friendship>> GetAllFriends(string userId);
    }
}

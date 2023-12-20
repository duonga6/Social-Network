using SocialNetwork.DataAccess.Entities;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IFriendshipRepository : IGenericRepository<Friendship>
    {
        Task<bool> IsFriend(string requestUserId, string targetUserId);
        Task<ICollection<Friendship>> GetAllFriendship(string userId);

    }
}

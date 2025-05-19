using SocialNetwork.DataAccess.Entities;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IFriendshipRepository : IGenericRepository<Friendship, Guid>
    {
        Task<ICollection<Friendship>> GetAllFriendshipAsync(string userId);
        Task<ICollection<string>> GetFriendIdsAsync(string userId);
        Task<bool> IsExistFriendshipAsync(string userId1, string userId2);
    }
}

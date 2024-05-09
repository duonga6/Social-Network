using SocialNetwork.DataAccess.Entities;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IFriendshipRepository : IGenericRepository<Friendship, Guid>
    {
        Task<ICollection<Friendship>> GetAllFriendship(string userId);
        Task<ICollection<string>> GetFriendIds(string userId);
    }
}

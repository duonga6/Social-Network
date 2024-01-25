using SocialNetwork.DataAccess.Entities;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IFriendshipRepository : IGenericRepository<Friendship, Guid>
    {
        Task<ICollection<Friendship>> GetAllFriendship(string userId);

    }
}

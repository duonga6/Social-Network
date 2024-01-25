using SocialNetwork.DataAccess.Entities;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<int> Count(Expression<Func<User, bool>> filter);
        Task<ICollection<User>> GetPaged(int pageSize, int pageNumber, Expression<Func<User, bool>> filter, Expression<Func<User, object>> orderBy, bool isDesc);
        Task<bool> Delete(string id);
        Task<User> GetById(string id, bool noTracking);
        Task<bool> Update(User user);
    }
}

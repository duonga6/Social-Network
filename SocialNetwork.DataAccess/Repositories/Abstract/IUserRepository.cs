using SocialNetwork.DataAccess.Entities;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task<int> Count(Expression<Func<User, bool>> filter);
        Task<ICollection<User>> GetPaged(int pageSize, int pageNumber, Expression<Func<User, bool>> filter, Expression<Func<User, object>> orderBy, bool isDesc);
        Task Delete(string id);
        Task<User> GetById(string id, bool noTracking = true);
        Task Update(User user);
        IQueryable<User> GetQueryable();
        Task<ICollection<User>> FindBy(Expression<Func<User, bool>> filter = null, bool asNoTracking = true);
        Task UpdateCoverImage(string id, string url);
        Task UpdateAvatar(string id, string url);
        Task SetLockoutEndDate(string id, DateTime? time);
    }
}

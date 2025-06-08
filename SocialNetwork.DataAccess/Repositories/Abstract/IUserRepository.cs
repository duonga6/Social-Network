using SocialNetwork.DataAccess.Entities;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task<int> CountAsync(Expression<Func<User, bool>> filter);
        Task<ICollection<User>> GetPagedAsync(int pageSize, int pageNumber, Expression<Func<User, bool>> filter, Expression<Func<User, object>> orderBy, bool isDesc);
        Task DeleteAsync(string id);
        Task<User> GetByIdAsync(string id, bool noTracking = true);
        Task UpdateAsync(User user);
        IQueryable<User> GetQueryable();
        Task<ICollection<User>> FindByAsync(Expression<Func<User, bool>> filter = null, bool asNoTracking = true);
        Task UpdateCoverImageAsync(string id, string url);
        Task UpdateAvatarAsync(string id, string url);
        Task SetLockoutEndDateAsync(string id, DateTime? time);
    }
}

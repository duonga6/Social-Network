using SocialNetwork.DataAccess.Entities;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IUserRepository : ISoftDeleteRepository<User, string>
    {
        Task<int> CountAsync(Expression<Func<User, bool>> filter);
        Task<User> GetByIdAsync(string id, bool noTracking = true);
        Task<ICollection<User>> FindByAsync(Expression<Func<User, bool>> filter = null, bool asNoTracking = true);
        Task UpdateCoverImageAsync(string id, string url);
        Task UpdateAvatarAsync(string id, string url);
        Task SetLockoutEndDateAsync(string id, DateTime? time);
    }
}

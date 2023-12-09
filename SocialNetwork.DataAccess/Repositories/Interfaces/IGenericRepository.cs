using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll(bool asNoTracking = true);
        Task<ICollection<T>> FindBy(Expression<Func<T, bool>> filter = null, bool asNoTracking = true);
        Task<T> FindOneBy(Expression<Func<T, bool>> filter = null, bool asNoTracking = true);
        Task<T> GetById(Guid id, bool asNoTracking = true);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
    }
}

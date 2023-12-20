using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll(bool asNoTracking = true);
        Task<ICollection<T>> FindBy(Expression<Func<T, bool>> filter = null, bool asNoTracking = true);
        Task<T> FindOneBy(Expression<Func<T, bool>> filter = null, bool asNoTracking = true);
        Task<ICollection<T>> GetPaged(int pageSize, int pageNumber, Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> orderBy = null, bool isDesc = true);
        Task<int> Count(Expression<Func<T, bool>> filter = null);
        Task<T> GetById(Guid id, bool asNoTracking = true);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
    }
}

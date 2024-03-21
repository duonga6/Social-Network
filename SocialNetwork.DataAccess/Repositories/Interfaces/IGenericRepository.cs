using SocialNetwork.DataAccess.Entities.Base;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<ICollection<TEntity>> GetAll(bool asNoTracking = true);
        Task<ICollection<TEntity>> FindBy(Expression<Func<TEntity, bool>> filter = null, bool asNoTracking = true);
        Task<TEntity> FindOneBy(Expression<Func<TEntity, bool>> filter = null, bool asNoTracking = true);
        Task<ICollection<TEntity>> GetPaged(int pageSize, int pageNumber, Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> orderBy = null, bool isDesc = true);
        Task<ICollection<TEntity>> GetCursorPaged(int pageSize, Expression<Func<TEntity, bool>> filter, bool getNext = true);
        Task<int> Count(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetById(TKey id, bool asNoTracking = true);
        Task Add(TEntity entity);
        Task AddRange(List<TEntity> entities);
        Task Update(TEntity entity);
        Task Delete(TKey id);
        Task<int> GetCount(Expression<Func<TEntity, bool>> filter = null);
        IQueryable<TEntity> GetQueryable();
    }
}

using SocialNetwork.DataAccess.Entities;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IGenericRepository<TEntity, in TKey> where TEntity : class, IEntityBase<TKey>, IDateTracking
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task<TEntity> GetByIdAsync(TKey id, Expression<Func<TEntity, object>>[] includes);
        Task<ICollection<TEntity>> GetAllAsync();
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);


        Task<ICollection<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>[] includes = null);
        Task<TEntity> FindOneByAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> FindOneByAsync(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>[] includes);

        Task<ICollection<TEntity>> GetPagedAsync(int pageSize, int pageNumber, Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> orderBy = null, bool isDesc = true);
        Task<ICollection<TEntity>> GetPagedAsync(int pageSize, int pageNumber, Expression<Func<TEntity, object>>[] includes, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderby, bool isDesc = true);


        Task<ICollection<TEntity>> GetCursorPagedAsync(int pageSize, Expression<Func<TEntity, bool>> filter, bool getNext = true);
        Task<ICollection<TEntity>> GetCursorPagedAsync(int pageSize, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>[] includes, bool getNext = true);
        Task<ICollection<TEntity>> GetCursorPagedAsync(int pageSize, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderBy, bool getNext = true);
        Task<ICollection<TEntity>> GetCursorPagedAsync(int pageSize, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderBy, Expression<Func<TEntity, object>>[] includes, bool getNext = true);

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);


        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TKey id);

        IQueryable<TEntity> GetQueryable();
    }
}

using SocialNetwork.DataAccess.Entities.Base;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetById(TKey id);
        Task<TEntity> GetById(TKey id, Expression<Func<TEntity, object>>[] includes);
        Task<ICollection<TEntity>> GetAll();
        Task<int> GetCount(Expression<Func<TEntity, bool>> filter = null);


        Task<ICollection<TEntity>> FindBy(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> FindOneBy(Expression<Func<TEntity, bool>> filter = null);

        Task<ICollection<TEntity>> GetPaged(int pageSize, int pageNumber, Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> orderBy = null, bool isDesc = true);
        Task<ICollection<TEntity>> GetPaged(int pageSize, int pageNumber, Expression<Func<TEntity, object>>[] includes, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderby, bool isDesc = true);


        Task<ICollection<TEntity>> GetCursorPaged(int pageSize, Expression<Func<TEntity, bool>> filter, bool getNext = true);

        Task Add(TEntity entity);
        Task AddRange(List<TEntity> entities);


        Task Update(TEntity entity);

        Task Delete(TKey id);

        IQueryable<TEntity> GetQueryable();
    }
}

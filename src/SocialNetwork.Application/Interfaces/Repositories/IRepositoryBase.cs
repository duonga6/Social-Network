using System.Linq.Expressions;

namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity, in TKey> where TEntity : class
    {
        TEntity GetById(TKey id);

        Task<TEntity> GetByIdAsync(TKey id);

        TEntity Get(Expression<Func<TEntity, bool>> expression = null, bool noTracking = false);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null, bool noTracking = false);

        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null, int? skip = null, int? take = null, bool noTracking = false);

        Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null, int? skip = null, int? take = null, bool noTracking = false);

        int GetCount(Expression<Func<TEntity, bool>> expression = null);

        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> expression = null);

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void AddRange(ICollection<TEntity> entities);

        Task AddRangeAsync(ICollection<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(ICollection<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(List<TEntity> entities);
    }
}

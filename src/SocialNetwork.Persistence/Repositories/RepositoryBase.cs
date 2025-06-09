using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.Interfaces.Repositories;
using System.Linq.Expressions;

namespace SocialNetwork.Persistence.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class, IEntityBase<TKey>
    {
        protected readonly ILogger logger;
        protected readonly AppDbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;

        public RepositoryBase(AppDbContext context, ILogger logger)
        {
            dbContext = context;
            dbSet = context.Set<TEntity>();
            this.logger = logger;
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void AddRange(ICollection<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public async Task AddRangeAsync(ICollection<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression = null, bool noTracking = false)
        {
            if (noTracking)
            {
                return dbSet.AsNoTracking().FirstOrDefault(expression);
            }
            else
            {
                return dbSet.FirstOrDefault(expression);
            }
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null, int? skip = null, int? take = null, bool noTracking = false)
        {
            var query = dbSet.Where(expression);

            if (skip.HasValue && take.HasValue)
            {
                query = query.Skip(skip.Value).Take(take.Value);
            }

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            return query.ToList();
        }

        public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null, int? skip = null, int? take = null, bool noTracking = false)
        {
            var query = dbSet.Where(expression);

            if (skip.HasValue && take.HasValue)
            {
                query = query.Skip(skip.Value).Take(take.Value);
            }

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null, bool noTracking = false)
        {
            if (noTracking)
            {
                return await dbSet.AsNoTracking().FirstOrDefaultAsync(expression);
            }
            else
            {
                return await dbSet.FirstOrDefaultAsync(expression);
            }
        }

        public TEntity GetById(TKey id)
        {
            return dbSet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await dbSet.FindAsync(id);
        }

        public int GetCount(Expression<Func<TEntity, bool>> expression = null)
        {
            return dbSet.Count(expression);
        }

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return await dbSet.CountAsync(expression);
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(List<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public void UpdateRange(ICollection<TEntity> entities)
        {
            dbSet.UpdateRange(entities);
        }
    }
}

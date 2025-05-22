using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class, IEntityBase<TKey>, IDateTracking
    {
        protected readonly ILogger _logger;
        protected AppDbContext _context;
        protected DbSet<TEntity> _dbSet;

        public GenericRepository(ILogger logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<ICollection<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>[] includes = null)
        {
            var query = _dbSet.AsNoTracking().Where(filter);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> FindOneByAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity> FindOneByAsync(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>>[] includes = null)
        {
            var query = _dbSet.AsNoTracking().Where(filter);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(List<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await GetByIdAsync(id, Array.Empty<Expression<Func<TEntity, object>>>());
        }

        // No implement
        public virtual Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.CountAsync();
        }

        public virtual async Task<ICollection<TEntity>> GetPagedAsync(int pageSize, int pageNumber, Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> orderBy = null, bool isDesc = true)
        {
            return await GetPagedAsync(pageSize, pageNumber, Array.Empty<Expression<Func<TEntity, object>>>(), filter, orderBy, isDesc);   
        }
        
        public virtual async Task<ICollection<TEntity>> GetPagedAsync(int pageSize, int pageNumber, Expression<Func<TEntity, object>>[] includes, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderby, bool isDesc = true)
        {
            var query = _dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            query = isDesc ? query.OrderByDescending(orderby) : query.OrderBy(orderby);

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        
        public IQueryable<TEntity> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(TKey id, Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsNoTracking().Where(x => x.Id.Equals(id));

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<ICollection<TEntity>> GetCursorPagedAsync(int pageSize, Expression<Func<TEntity, bool>> filter, bool getNext = true)
        {
            return await GetCursorPagedAsync(pageSize, filter, Array.Empty<Expression<Func<TEntity, object>>>(), getNext);
        }

        public virtual async Task<ICollection<TEntity>> GetCursorPagedAsync(int pageSize, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>[] includes, bool getNext = true)
        {
            var query = _dbSet.AsNoTracking().Where(filter);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (getNext)
            {
                return await query.OrderByDescending(x => x.CreatedDate).ThenByDescending(x => x.Id).Take(pageSize).ToListAsync();
            }
            else
            {
                var result = await query.OrderBy(x => x.CreatedDate).ThenBy(x => x.Id).Take(pageSize).ToListAsync();
                result.Reverse();
                return result;
            }
        }

        public virtual async Task<ICollection<TEntity>> GetCursorPagedAsync(int pageSize, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderBy, bool getNext = true)
        {
            return await GetCursorPagedAsync(pageSize, filter, orderBy, Array.Empty<Expression<Func<TEntity, object>>>(), getNext);
        }

        public virtual async Task<ICollection<TEntity>> GetCursorPagedAsync(int pageSize, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderBy, Expression<Func<TEntity, object>>[] includes, bool getNext = true)
        {
            var query = _dbSet.AsNoTracking().Where(filter);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (getNext)
            {
                return await query.OrderByDescending(orderBy).ThenByDescending(x => x.Id).Take(pageSize).ToListAsync();
            }
            else
            {
                var result = await query.OrderBy(orderBy).ThenBy(x => x.Id).Take(pageSize).ToListAsync();
                result.Reverse();
                return result;
            }
        }
    }
}

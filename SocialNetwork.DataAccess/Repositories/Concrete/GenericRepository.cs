using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
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

        public virtual async Task<ICollection<TEntity>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<ICollection<TEntity>> FindBy(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>[] includes = null)
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

        public virtual async Task<TEntity> FindOneBy(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity> FindOneBy(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>>[] includes = null)
        {
            var query = _dbSet.AsNoTracking().Where(filter);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task AddRange(List<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public virtual async Task<TEntity> GetById(TKey id)
        {
            return await GetById(id, Array.Empty<Expression<Func<TEntity, object>>>());
        }

        // No implement
        public virtual Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task Delete(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public virtual async Task<int> GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.CountAsync();
        }

        public virtual async Task<ICollection<TEntity>> GetPaged(int pageSize, int pageNumber, Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> orderBy = null, bool isDesc = true)
        {
            return await GetPaged(pageSize, pageNumber, Array.Empty<Expression<Func<TEntity, object>>>(), filter, orderBy, isDesc);   
        }
        
        public virtual async Task<ICollection<TEntity>> GetPaged(int pageSize, int pageNumber, Expression<Func<TEntity, object>>[] includes, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderby, bool isDesc = true)
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

        public async Task<TEntity> GetById(TKey id, Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsNoTracking().Where(x => x.Id.Equals(id) && x.Status == 1);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<ICollection<TEntity>> GetCursorPaged(int pageSize, Expression<Func<TEntity, bool>> filter, bool getNext = true)
        {
            return await GetCursorPaged(pageSize, filter, Array.Empty<Expression<Func<TEntity, object>>>(), getNext);
        }

        public virtual async Task<ICollection<TEntity>> GetCursorPaged(int pageSize, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>[] includes, bool getNext = true)
        {
            var query = _dbSet.AsNoTracking().Where(filter);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (getNext)
            {
                return await query.OrderByDescending(x => x.CreatedAt).ThenByDescending(x => x.Id).Take(pageSize).ToListAsync();
            }
            else
            {
                var result = await query.OrderBy(x => x.CreatedAt).ThenBy(x => x.Id).Take(pageSize).ToListAsync();
                result.Reverse();
                return result;
            }
        }

        public virtual async Task<ICollection<TEntity>> GetCursorPaged(int pageSize, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderBy, bool getNext = true)
        {
            return await GetCursorPaged(pageSize, filter, orderBy, Array.Empty<Expression<Func<TEntity, object>>>(), getNext);
        }

        public virtual async Task<ICollection<TEntity>> GetCursorPaged(int pageSize, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderBy, Expression<Func<TEntity, object>>[] includes, bool getNext = true)
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

        public async Task RestoreEntity(TKey id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entity != null)
            {
                entity.Status = 1;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities.Base;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected readonly ILogger _logger;
        protected AppDbContext _context;
        internal DbSet<TEntity> _dbSet;
        public GenericRepository(ILogger logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<ICollection<TEntity>> GetAll(bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().ToListAsync();
            }
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<ICollection<TEntity>> FindBy(Expression<Func<TEntity, bool>> filter = null, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().Where(filter).ToListAsync();
            }
            return await _dbSet.Where(filter).ToListAsync();
        }

        public virtual async Task<TEntity> FindOneBy(Expression<Func<TEntity, bool>> filter = null, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(filter);
            }
            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public virtual async Task<bool> Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<TEntity> GetById(TKey id, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
            }   
            else
            {
                return await _dbSet.FindAsync(id);
            }
        }

        // No implement
        public virtual Task<bool> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> Delete(TKey id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null) { return false; }

                _dbSet.Remove(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} error function: Delete", typeof(ReactionRepository));
                throw;
            }
        }

        public virtual async Task<int> GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _dbSet.AsNoTracking().Where(filter).CountAsync();
        }

        public virtual async Task<ICollection<TEntity>> GetPaged(int pageSize, int pageNumber, Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> orderBy = null, bool isDesc = true)

        {
            var query = _dbSet
                .AsNoTracking()
                .Where(filter);

            if (isDesc)
            {
                query = query.OrderByDescending(orderBy);
            }
            else
            {
                query = query.OrderBy(orderBy);

            }

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        
        public async Task<ICollection<TEntity>> GetCursorPaged(int pageSize, Expression<Func<TEntity, object>> orderBy, Expression<Func<TEntity, bool>> filter, bool isDesc = true)
        {
            var query = _dbSet.AsNoTracking();
            if (isDesc)
            {
                query = query.OrderByDescending(orderBy);
            } else
            {
                query = query.OrderBy(orderBy);
            }

            return await query.Where(filter).Take(pageSize).ToListAsync();
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> filter = null)

        {
            return await _dbSet
                .AsNoTracking()
                .Where(filter)
                .CountAsync();
        }
        
        public IQueryable<TEntity> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }
    }
}

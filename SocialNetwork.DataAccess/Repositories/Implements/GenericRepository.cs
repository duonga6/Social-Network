using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ILogger _logger;
        protected AppDbContext _context;
        internal DbSet<T> _dbSet;
        public GenericRepository(ILogger logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<ICollection<T>> GetAll(bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().ToListAsync();
            }
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<ICollection<T>> FindBy(Expression<Func<T, bool>> filter = null, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().Where(filter).ToListAsync();
            }
            return await _dbSet.Where(filter).ToListAsync();
        }

        public virtual async Task<T> FindOneBy(Expression<Func<T, bool>> filter = null, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(filter);
            }
            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        // No implement
        public virtual Task<T> GetById(Guid id, bool asNoTracking = true)
        {

            throw new NotImplementedException();
        }

        // No implement
        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
        // No implement
        public virtual Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ICollection<T>> GetPaged(int pageSize, int pageNumber, Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> orderBy = null, bool isDesc = true)
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
        public async Task<int> Count(Expression<Func<T, bool>> filter = null)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(filter)
                .CountAsync();
        }

    }
}

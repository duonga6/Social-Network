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

        public virtual async Task<bool> Add(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual async Task<ICollection<T>> FindBy(Expression<Func<T, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(filter).ToListAsync(cancellationToken);
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Chưa triển khai
        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
        // Chưa
        public virtual Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        // Chưa
        public virtual Task<ICollection<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> FindOneBy(Expression<Func<T, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstOrDefaultAsync(filter, cancellationToken);
        }
    }
}

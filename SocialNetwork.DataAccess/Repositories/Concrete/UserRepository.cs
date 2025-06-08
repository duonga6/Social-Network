using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using System.Linq;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<User> _dbSet;
        private readonly ILogger _logger;

        public UserRepository(ILogger logger, AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<User>();
            _logger = logger;
        }

        public async Task<int> CountAsync(Expression<Func<User, bool>> filter)
        {
            return await _dbSet.AsNoTracking().Where(filter).CountAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var user = await _dbSet.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
            }
        }

        public async Task<User> GetByIdAsync(string id, bool noTracking = true)
        {
            var query = _dbSet.Include(x => x.Gender_FK).AsQueryable();
            
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<User>> GetPagedAsync(int pageSize, int pageNumber, Expression<Func<User, bool>> filter, Expression<Func<User, object>> orderBy, bool isDesc)
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

        public async Task UpdateAsync(User user)
        {
            var updateUser = await _dbSet.FindAsync(user.Id);

            if (updateUser != null)
            {
                updateUser.FirstName = user.FirstName;
                updateUser.LastName = user.LastName;
                updateUser.Address = user.Address;
                updateUser.DateOfBirth = user.DateOfBirth;
                updateUser.Gender = user.Gender;
            }
        }

        public IQueryable<User> GetQueryable() => _dbSet.AsQueryable();

        public virtual async Task<ICollection<User>> FindByAsync(Expression<Func<User, bool>> filter = null, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().Where(filter).ToListAsync();
            }
            return await _dbSet.Where(filter).ToListAsync();
        }

        public async Task UpdateCoverImageAsync(string id, string url)
        {
            var user = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                user.CoverImageUrl = url;
            }
        }

        public async Task UpdateAvatarAsync(string id, string url)
        {
            var user = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                user.AvatarUrl= url;
            }
        }

        public async Task SetLockoutEndDateAsync(string id, DateTime? time)
        {
            var user = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                user.LockoutEnd = time;
            }
        }
    }
}

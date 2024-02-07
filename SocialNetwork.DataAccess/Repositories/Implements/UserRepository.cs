using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Implements
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

        public async Task<int> Count(Expression<Func<User, bool>> filter)
        {
            return await _dbSet.AsNoTracking().Where(filter).CountAsync();
        }

        public async Task<bool> Delete(string id)
        {
            var user = await _dbSet.FindAsync(id);
            user.Status = 0;

            return true;
        }

        public async Task<User> GetById(string id, bool noTracking = true)
        {
            if (noTracking)
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }    

            return await _dbSet.FindAsync(id);
        }

        public async Task<ICollection<User>> GetPaged(int pageSize, int pageNumber, Expression<Func<User, bool>> filter, Expression<Func<User, object>> orderBy, bool isDesc)
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

        public async Task<bool> Update(User user)
        {
            var updateUser = await _dbSet.FindAsync(user.Id);

            updateUser.FirstName = user.FirstName;
            updateUser.LastName = user.LastName;
            updateUser.Address = user.Address;
            updateUser.PhoneNumber = updateUser.PhoneNumber;
            updateUser.DateOfBirth = updateUser.DateOfBirth;

            return true;
        }
    }
}

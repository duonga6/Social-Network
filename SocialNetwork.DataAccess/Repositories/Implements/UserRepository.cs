using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task<ICollection<User>> GetAll(bool asNoTracking = true) 
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().ToListAsync();
            }

            return await _dbSet.ToListAsync();
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Email == email && x.Status == 1);
        }

        public async Task<User> FindById(string id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Status == 1);
        }
    
        public override async Task<bool> Update(User entity)
        {
            var entityUpdate = await _dbSet.FindAsync(entity.Id);
            if (entityUpdate == null) { return false; }

            entityUpdate.FirstName = entity.FirstName;
            entityUpdate.LastName = entity.LastName;
            entityUpdate.Address = entity.Address;
            entityUpdate.DateOfBirth = entity.DateOfBirth;
            entityUpdate.PhoneNumber = entity.PhoneNumber;

            return true;
        }
    
        public override async Task<bool> Delete(Guid Id)
        {
            var entity = await _dbSet.FindAsync(Id);
            if (entity == null) return false;

            entity.Status = 0;
            entity.UpdatedAt = DateTime.UtcNow;

            return true;
        }

        public async Task<bool> Delete(string id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;

            entity.Status = 0;
            entity.UpdatedAt = DateTime.UtcNow;

            return true;
        }
    }
}

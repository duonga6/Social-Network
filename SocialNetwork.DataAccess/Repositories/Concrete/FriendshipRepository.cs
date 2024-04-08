using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.DataAccess.Utilities.Enum;
using System.Linq;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class FriendshipRepository : GenericRepository<Friendship, Guid>, IFriendshipRepository
    {
        public FriendshipRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task<ICollection<Friendship>> GetAll(bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().ToListAsync();
            }   
            return await _dbSet.ToListAsync();
        }

        public override async Task Update(Friendship entity)
        {
            var entityUpdate = await _dbSet.FindAsync(entity.Id);
            if (entityUpdate != null) 
            { 
                entityUpdate.Status = entity.Status;
                entityUpdate.UpdatedAt = DateTime.UtcNow;
            }
        }

        public async Task<ICollection<Friendship>> GetAllFriendship(string userId)
        {
            var friends = await _dbSet.Where(x => (x.TargetUserId == userId || x.RequestUserId == userId) && x.FriendshipTypeId == (int)FriendshipEnum.Accepted)
                                        .AsNoTracking()
                                        .ToListAsync();

            return friends;
        }

        public override async Task<ICollection<Friendship>> FindBy(Expression<Func<Friendship, bool>> filter = null, bool asNoTracking = true)
        {
            var query = _dbSet
                .Include(x => x.RequestUser)
                .Include(x => x.TargetUser)
                .Where(filter)
                .OrderByDescending(x => x.CreatedAt);
            
            if (asNoTracking)
            {
                return await query.AsNoTracking().ToListAsync();
            }
            return await query.ToListAsync();
        }

        public override async Task<Friendship> GetById(Guid id, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }    

            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<ICollection<Friendship>> GetPaged(int pageSize,
                                                                     int pageNumber,
                                                                     Expression<Func<Friendship, bool>> filter = null,
                                                                     Expression<Func<Friendship, object>> orderBy = null,
                                                                     bool isDesc = true)
        {
            var query = _dbSet
                .AsNoTracking()
                .Include(x => x.TargetUser)
                .Include(x => x.RequestUser)
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
    }
}

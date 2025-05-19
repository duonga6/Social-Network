using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Enums;
using SocialNetwork.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class FriendshipRepository : GenericRepository<Friendship, Guid>, IFriendshipRepository
    {
        public FriendshipRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task UpdateAsync(Friendship entity)
        {
            var entityUpdate = await _dbSet.FindAsync(entity.Id);
            if (entityUpdate != null) 
            { 
                entityUpdate.IsDeleted = entity.IsDeleted;
                entityUpdate.FriendshipTypeId = entity.FriendshipTypeId;
                entityUpdate.ModifiedDate = DateTime.UtcNow;
            }
        }

        public async Task<ICollection<Friendship>> GetAllFriendshipAsync(string userId)
        {
            var friends = await _dbSet.Where(x => (x.TargetUserId == userId || x.RequestUserId == userId) && x.FriendshipTypeId == (int)FriendshipEnum.Accepted)
                                        .AsNoTracking()
                                        .ToListAsync();

            return friends;
        }

        public override async Task<Friendship> GetByIdAsync(Guid id)
        {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<ICollection<Friendship>> GetPagedAsync(int pageSize,
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

        public async Task<ICollection<string>> GetFriendIdsAsync(string userId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(x => (x.RequestUserId == userId || x.TargetUserId == userId) && !x.IsDeleted && x.FriendshipTypeId == (int)FriendshipEnum.Accepted)
                .Select(x => x.RequestUserId == userId ? x.TargetUserId : x.RequestUserId)
                .ToListAsync();
        }

        public async Task<bool> IsExistFriendshipAsync(string userId1, string userId2)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(
                x => 
                ((x.RequestUserId == userId1 && x.TargetUserId == userId2) || (x.RequestUserId == userId2 && x.TargetUserId == userId1)) &&
                !x.IsDeleted &&
                x.FriendshipTypeId == (int) FriendshipEnum.Accepted
                ) != null;
            
        }
    }
}

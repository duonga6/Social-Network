using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class FriendshipRepository : GenericRepository<Friendship>, IFriendshipRepository
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

        public override async Task<bool> Update(Friendship entity)
        {
            var entityUpdate = await _dbSet.FindAsync(entity.Id);
            if (entityUpdate == null) { return false; }
            
            entityUpdate.RequestUserId = entity.RequestUserId;
            entityUpdate.TargetUserId = entity.TargetUserId;  
            entityUpdate.Status = entity.Status;
            entityUpdate.UpdatedAt = DateTime.UtcNow;

            return true;
        }

        public override async Task<bool> Delete(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) { return false; }

            _dbSet.Remove(entity);
            return true;
        }
    
        public async Task<bool> IsFriend(string requestUserId, string targetUserId)
        {
            var isFriend = await _dbSet
                .FirstOrDefaultAsync(
                x => (x.TargetUserId == requestUserId && x.RequestUserId == targetUserId && x.FriendStatus == FriendshipStatus.Accepted)
             || (x.TargetUserId == targetUserId && x.RequestUserId == requestUserId && x.FriendStatus == FriendshipStatus.Accepted));

            return isFriend != null;
        }
    
    }
}

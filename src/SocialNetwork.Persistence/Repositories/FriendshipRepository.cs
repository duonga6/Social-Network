using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Enums;

namespace SocialNetwork.Persistence.Repositories
{
    public class FriendshipRepository : RepositoryBase<Friendship, Guid>, IFriendshipRepository
    {
        public FriendshipRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<ICollection<Friendship>> GetAllFriendshipAsync(string userId)
        {
            return await dbSet
                .Where(x => (x.TargetUserId == userId || x.RequestUserId == userId) && x.FriendshipStatus == FriendshipStatus.Accepted)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<string>> GetFriendIdsAsync(string userId)
        {
            return await dbSet
                .AsNoTracking()
                .Where(x => (x.RequestUserId.Equals(userId) || x.TargetUserId.Equals(userId)) && !x.IsDeleted && x.FriendshipStatus == FriendshipStatus.Accepted)
                .Select(x => x.RequestUserId.Equals(userId) ? x.TargetUserId : x.RequestUserId)
                .ToListAsync();
        }

        public async Task<FriendshipStatus> GetStatusAsync(string userId1, string userId2)
        {
            return await dbSet
                .AsNoTracking()
                .Where(x => (x.RequestUserId.Equals(userId1) && x.TargetUserId.Equals(userId2)) ||
                            (x.RequestUserId.Equals(userId2) && x.TargetUserId.Equals(userId1)))
                .Select(x => x.FriendshipStatus)
                .FirstOrDefaultAsync();
        }
    }
}

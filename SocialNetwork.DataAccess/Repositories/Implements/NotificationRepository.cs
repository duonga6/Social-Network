using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class NotificationRepository : GenericRepository<NotificationService>, INotificationRepository
    {
        public NotificationRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public async Task<bool> Seen(Guid Id)
        {
            var entity = await _dbSet.FindAsync(Id);
            if (entity == null) { return false; }

            entity.Seen = true;
            return true;
        }

        public async Task<ICollection<NotificationService>> GetUserNotifications(string userId)
        {
            var notifications = await _dbSet.AsNoTracking()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
            return notifications;
        }

        public override async Task<NotificationService> GetById(Guid id, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }

            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Status == 1);
        }
    }
}

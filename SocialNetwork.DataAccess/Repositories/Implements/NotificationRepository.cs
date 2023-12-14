using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
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
    }
}

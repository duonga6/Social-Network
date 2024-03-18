using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class NotificationRepository : GenericRepository<Notification, Guid>, INotificationRepository
    {
        public NotificationRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public async Task<bool> Seen(Guid Id)
        {
            var entity = await _dbSet.FindAsync(Id);
            if (entity == null) { return false; }

            entity.ReadAt = DateTime.UtcNow;

            return true;
        }

        public async Task<ICollection<Notification>> GetUserNotifications(string userId)
        {
            var notifications = await _dbSet.AsNoTracking()
                .Where(x => x.UserId == userId)
                .Include(x => x.User)
                .Include(x => x.NotificationDetail)
                .ThenInclude(x => x.Author)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
            return notifications;
        }

        public override async Task<Notification> GetById(Guid id, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }

            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Status == 1);
        }

        public override async Task<ICollection<Notification>> GetPaged(int pageSize, int pageNumber, Expression<Func<Notification, bool>> filter = null, Expression<Func<Notification, object>> orderBy = null, bool isDesc = true)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(filter)
                .Include(x => x.User)
                .Include(x => x.NotificationDetail)
                .ThenInclude(x => x.Author)
                .AsQueryable();

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

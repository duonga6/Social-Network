using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using System.Linq;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class NotificationRepository : GenericRepository<Notification, Guid>, INotificationRepository
    {
        public NotificationRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public async Task Seen(Guid Id)
        {
            var entity = await _dbSet.FindAsync(Id);
            if (entity != null) 
            { 
                entity.ReadAt = DateTime.UtcNow;
            }
        }

        public async Task<ICollection<Notification>> GetUserNotifications(string userId)
        {
            var notifications = await _dbSet.AsNoTracking()
                .Where(x => x.ToId == userId)
                .Include(x => x.FromUser)
                .Include(x => x.ToUser)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
            return notifications;
        }

        public override async Task<Notification> GetById(Guid id)
        {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        }

        public override async Task<ICollection<Notification>> GetPaged(int pageSize, int pageNumber, Expression<Func<Notification, bool>> filter = null, Expression<Func<Notification, object>> orderBy = null, bool isDesc = true)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(filter)
                .Include(x => x.FromUser)
                .Include(x => x.ToUser)
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

        public override async Task<ICollection<Notification>> GetCursorPaged(int pageSize, Expression<Func<Notification, bool>> filter, bool getNext = true)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(filter)
                .Include(x => x.FromUser)
                .Include(x => x.ToUser);

            if (getNext)
            {
                return await query.OrderByDescending(x => x.CreatedAt).ThenByDescending(x => x.Id).Take(pageSize).ToListAsync();
            }
            else
            {
                var result = await query.OrderBy(x => x.CreatedAt).ThenBy(x => x.Id).Take(pageSize).ToListAsync();
                result.Reverse();
                return result;
            }
        }

    }
}

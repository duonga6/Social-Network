using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task<Message> GetById(Guid id, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }

            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<bool> Delete(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            entity.Status = 0;
            entity.UpdatedAt = DateTime.UtcNow;

            return true;
        }

        public async Task<ICollection<Message>> GetConversation(string senderId, string receiverId)
        {
            var messages = await _dbSet
                .Where(x => (x.SenderId == senderId && x.ReceiverId == receiverId || x.SenderId == receiverId && x.ReceiverId == senderId) && x.Status == 1)
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
            return messages;
        }

        public virtual async Task<ICollection<Message>> GetPaged(int pageSize, int pageNumber, Expression<Func<Message, bool>> filter = null, Expression<Func<Message, object>> orderBy = null, bool isDesc = true)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(filter)
                .Include(x => x.Sender)
                .Include(x => x.Receiver)
                .AsSplitQuery();

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

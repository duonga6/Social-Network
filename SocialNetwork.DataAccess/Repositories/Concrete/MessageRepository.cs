using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class MessageRepository : GenericRepository<Message, Guid>, IMessageRepository
    {
        public MessageRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task<Message> GetById(Guid id)
        {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
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

        public override async Task<ICollection<Message>> GetPaged(int pageSize, int pageNumber, Expression<Func<Message, bool>> filter = null, Expression<Func<Message, object>> orderBy = null, bool isDesc = true)
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

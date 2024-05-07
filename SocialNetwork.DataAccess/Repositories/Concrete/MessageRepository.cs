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

        public async Task RevokeMessage(Guid messageId)
        {
            var message = await _dbSet.FirstOrDefaultAsync(x => x.Id == messageId);
            if (message != null)
            {
                message.Content = "";
                message.RevokedAt = DateTime.UtcNow;
            }
        }

        public async Task SeenMessage(Guid messageId)
        {
            var message = await _dbSet.FirstOrDefaultAsync(x => x.Id == messageId);
            if (message != null)
            {
                message.ReadedAt = DateTime.UtcNow;
            }
        }
    }
}

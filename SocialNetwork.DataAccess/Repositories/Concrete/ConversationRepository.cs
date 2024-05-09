using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class ConversationRepository : GenericRepository<Conversation, Guid>, IConversationRepository
    {
        public ConversationRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task Update(Conversation conversation)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == conversation.Id);
            if (entity != null)
            {
                entity.Name = conversation.Name;
                entity.Image = conversation.Image;
            }
        }

        public async Task UpdateNewestMessage(Guid conversationId)
        {
            var conversation = await _dbSet.FirstOrDefaultAsync(x => x.Id == conversationId);
            if (conversation != null)
            {
                conversation.UpdatedAt = DateTime.UtcNow;
            }
        }

        public override async Task Delete(Guid id)
        {
            var conversation = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (conversation != null)
            {
                conversation.Status = 0;
            }
        }
    }
}

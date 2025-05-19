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

        public override async Task UpdateAsync(Conversation conversation)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == conversation.Id);
            if (entity != null)
            {
                entity.Name = conversation.Name;
                entity.Image = conversation.Image;
                entity.ModifiedDate = DateTime.UtcNow;
            }
        }

        public async Task UpdateNewestMessageAsync(Guid conversationId)
        {
            var conversation = await _dbSet.FirstOrDefaultAsync(x => x.Id == conversationId);
            if (conversation != null)
            {
                conversation.ModifiedDate = DateTime.UtcNow;
            }
        }

        public override async Task DeleteAsync(Guid id)
        {
            var conversation = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (conversation != null)
            {
                conversation.IsDeleted = true;
            }
        }
    }
}

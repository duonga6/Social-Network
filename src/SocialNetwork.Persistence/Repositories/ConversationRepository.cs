using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Persistence.Repositories
{
    public class ConversationRepository : RepositoryBase<Conversation, Guid>, IConversationRepository
    {
        public ConversationRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override void Update(Conversation conversation)
        {
            var entity = dbSet.Find(conversation.Id);
            entity.Name = conversation.Name;
            entity.Image = conversation.Image;
            entity.ModifiedDate = DateTime.UtcNow;
        }

        public async Task UpdateNewestMessageAsync(Guid conversationId)
        {
            var conversation = await dbSet.FirstOrDefaultAsync(x => x.Id.Equals(conversationId));
            conversation.ModifiedDate = DateTime.UtcNow;
        }
    }
}

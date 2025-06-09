using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Persistence.Repositories
{
    public class ConversationParticipantRepository : RepositoryBase<ConversationParticipant, Guid>, IConversationParticipantRepository
    {
        public ConversationParticipantRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task AddParticipantExistedAsync(Guid id)
        {
            var pariticipant = await dbSet.Where(x => x.Id.Equals(id)).Include(x => x.User).FirstOrDefaultAsync();
            
            pariticipant.IsDeleted = false;
            pariticipant.IsAdmin = false;
            pariticipant.IsSuperAdmin = false;
            pariticipant.UserContactName = $"{pariticipant.User.FirstName} {pariticipant.User.LastName}";
            pariticipant.CreatedDate = DateTime.UtcNow;
        }

        public async Task<List<Guid>> GetConversationParticipantIdsAsync(Guid conversationId)
        {
            return await dbSet
                .AsNoTracking()
                .Where(x => x.ConversationId.Equals(conversationId))
                .Include(x => x.User)
                .Select(x => x.User.Id)
                .ToListAsync();
        }
    }
}

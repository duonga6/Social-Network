using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class ConversationParticipantRepository : GenericRepository<ConversationParticipant, Guid>, IConversationParticipantRepository
    {
        public ConversationParticipantRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task Update(ConversationParticipant entity)
        {
            var participant = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (participant != null)
            {
                participant.UserContactName = entity.UserContactName;
                participant.IsAdmin = entity.IsAdmin;
            }
        }

        public async Task<List<string>> GetConversationParticipantId(Guid conversationId)
        {
            return await _dbSet.AsNoTracking()
                .Where(x => x.ConversationId == conversationId)
                .Include(x => x.User)
                .Select(x => x.User.Id)
                .ToListAsync();
        }
    }
}

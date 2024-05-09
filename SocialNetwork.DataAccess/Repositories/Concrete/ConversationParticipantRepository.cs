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
                participant.IsSuperAdmin = entity.IsSuperAdmin;
                participant.UpdatedAt = entity.UpdatedAt;
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

        public override async Task Delete(Guid id)
        {
            var participant = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (participant != null)
            {
                participant.Status = 0;
                participant.IsAdmin = false;
                participant.IsSuperAdmin = false;
            }
        }

        public async Task AddParticipantExisted(Guid id)
        {
            var pariticipant = await _dbSet.Where(x => x.Id == id).Include(x => x.User).FirstOrDefaultAsync();
            if (pariticipant != null)
            {
                pariticipant.Status = 1;
                pariticipant.IsAdmin = false;
                pariticipant.IsSuperAdmin = false;
                pariticipant.UserContactName = pariticipant.User.GetFullName();
                pariticipant.CreatedAt = DateTime.UtcNow;
            }
        }
    }
}

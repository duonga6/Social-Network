using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IConversationParticipantRepository : IGenericRepository<ConversationParticipant, Guid>
    {
        Task<List<string>> GetConversationParticipantIdAsync(Guid conversationId);
        Task AddParticipantExistedAsync(Guid id);
    }
}

using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IConversationParticipantRepository : IGenericRepository<ConversationParticipant, Guid>
    {
        Task<List<string>> GetConversationParticipantId(Guid conversationId);
    }
}

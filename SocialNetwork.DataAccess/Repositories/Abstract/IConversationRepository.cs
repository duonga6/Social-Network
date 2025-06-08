using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IConversationRepository : IGenericRepository<Conversation, Guid>
    {
        Task UpdateNewestMessage(Guid conversationId);
    }
}

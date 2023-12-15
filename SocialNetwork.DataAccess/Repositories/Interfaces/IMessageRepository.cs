using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IMessageRepository : IGenericRepository<MessageService>
    {
        Task<ICollection<MessageService>> GetConversation(string senderId, string receiverId);
    }
}

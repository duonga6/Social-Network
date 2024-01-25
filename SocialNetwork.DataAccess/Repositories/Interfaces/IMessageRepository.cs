using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message, Guid>
    {
        Task<ICollection<Message>> GetConversation(string senderId, string receiverId);
    }
}

using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IMessageRepository : IGenericRepository<Message, Guid>
    {
        Task<ICollection<Message>> GetConversation(string senderId, string receiverId);
    }
}

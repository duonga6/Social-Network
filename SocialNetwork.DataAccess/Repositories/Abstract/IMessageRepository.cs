using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IMessageRepository : IGenericRepository<Message, Guid>
    {
        Task RevokeMessage(Guid messageId);
        Task SeenMessage(Guid messageId);
    }
}

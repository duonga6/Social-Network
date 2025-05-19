using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IMessageRepository : IGenericRepository<Message, Guid>
    {
        Task RevokeMessageAsync(Guid messageId);
        Task SeenMessageAsync(Guid messageId);
    }
}

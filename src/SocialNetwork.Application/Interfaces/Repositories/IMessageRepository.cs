namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface IMessageRepository : IRepositoryBase<Message, Guid>
    {
        Task RevokeMessageAsync(Guid messageId);
        Task SeenMessageAsync(Guid messageId);
    }
}

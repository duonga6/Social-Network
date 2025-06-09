namespace SocialNetwork.Persistence.Repositories
{
    public class MessageRepository : RepositoryBase<Message, Guid>, IMessageRepository
    {
        public MessageRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public Task RevokeMessageAsync(Guid messageId)
        {
            throw new NotImplementedException();
        }

        public Task SeenMessageAsync(Guid messageId)
        {
            throw new NotImplementedException();
        }
    }
}

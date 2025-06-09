namespace SocialNetwork.Persistence.Repositories
{
    public class MessageMemberReadRepository : RepositoryBase<MessageMemberReaded, Guid>, IMessageMemberReadRepository
    {
        public MessageMemberReadRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}

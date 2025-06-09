namespace SocialNetwork.Persistence.Repositories
{
    public class GroupInviteRepository : RepositoryBase<GroupInvite, Guid>, IGroupInviteRepository
    {
        public GroupInviteRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}

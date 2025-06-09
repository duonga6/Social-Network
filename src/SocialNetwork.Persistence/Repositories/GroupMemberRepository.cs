namespace SocialNetwork.Persistence.Repositories
{
    public class GroupMemberRepository : RepositoryBase<GroupMember, Guid>, IGroupMemberRepository
    {
        public GroupMemberRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}

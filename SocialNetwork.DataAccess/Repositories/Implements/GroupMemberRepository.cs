using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class GroupMemberRepository : GenericRepository<GroupMember, Guid>, IGroupMemberRepository
    {
        public GroupMemberRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }
    }
}

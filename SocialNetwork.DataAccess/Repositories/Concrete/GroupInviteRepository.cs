using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class GroupInviteRepository : GenericRepository<GroupInvite, Guid>, IGroupInviteRepository
    {
        public GroupInviteRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }
    }
}

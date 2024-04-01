using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class GroupAdminRepository : GenericRepository<GroupAdministrator, Guid>, IGroupAdminRepository
    {
        public GroupAdminRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }
    }
}

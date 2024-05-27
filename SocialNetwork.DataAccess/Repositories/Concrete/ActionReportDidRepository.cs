using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class ActionReportDidRepository : GenericRepository<ActionReportDid, Guid>, IActionReportDidRepository
    {
        public ActionReportDidRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }
    }
}

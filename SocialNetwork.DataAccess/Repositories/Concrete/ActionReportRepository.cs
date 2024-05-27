using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class ActionReportRepository : GenericRepository<ActionReport, int>, IActionReportRepository
    {
        public ActionReportRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }
    }
}

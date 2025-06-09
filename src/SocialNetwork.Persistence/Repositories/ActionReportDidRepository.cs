namespace SocialNetwork.Persistence.Repositories
{
    internal class ActionReportDidRepository : RepositoryBase<ActionReportDid, Guid>, IActionReportDidRepository
    {
        public ActionReportDidRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}

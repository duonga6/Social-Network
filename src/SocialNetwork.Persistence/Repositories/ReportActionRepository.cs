namespace SocialNetwork.Persistence.Repositories
{
    public class ReportActionRepository : RepositoryBase<ReportAction, int>, IReportActionRepository
    {
        public ReportActionRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}

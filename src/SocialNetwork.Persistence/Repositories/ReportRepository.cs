using SocialNetwork.Application.Interfaces.Repositories;

namespace SocialNetwork.Persistence.Repositories
{
    public class ReportRepository : RepositoryBase<ReportViolation, Guid>, IReportRepository
    {
        public ReportRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public Task MarkProccessedAsync(Guid Id, string userId)
        {
            throw new NotImplementedException();
        }
    }
}

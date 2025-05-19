using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class ReportRepository : GenericRepository<ReportViolation, Guid>, IReportRepository
    {
        public ReportRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public async Task MarkProccessedAsync(Guid Id, string userId)
        {
            var report = await _dbSet.FirstOrDefaultAsync(x => x.Id == Id);
            if (report != null)
            {
                report.IsSolved = true;
                report.SolvedById = userId;
                report.SolvedAt = DateTime.UtcNow;
            }
        }
    }
}

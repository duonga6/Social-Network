using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IReportRepository : IGenericRepository<ReportViolation, Guid>
    {
        Task MarkProccessed(Guid Id, string userId);
    }
}

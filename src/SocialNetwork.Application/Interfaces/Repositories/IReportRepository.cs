namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface IReportRepository : IRepositoryBase<ReportViolation, Guid>
    {
        Task MarkProccessedAsync(Guid Id, string userId);
    }
}

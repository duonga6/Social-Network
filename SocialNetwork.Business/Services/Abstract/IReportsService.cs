using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Wrapper.Abstract;
using SocialNetwork.DataAccess.Enums;

namespace SocialNetwork.Business.Services.Abstract
{
    public interface IReportsService
    {
        Task<IResponse> CreateReport(string requestId, CreateReportRequest request);
        Task<IResponse> GetReport(string requestId, int pageSize, int pageNumber, string? searchString, ReportTypeEnum? type);
        Task<IResponse> GetReportById(string requestId, Guid Id);
        Task<IResponse> MarkProccessed(string requestId, Guid Id);

        Task<IResponse> GetActionReport(string requestId, Guid Id);
        Task<IResponse> CreateActionReport(string requestId, Guid Id, CreateReportActionRequest request);
        Task<IResponse> DeleteActionReport(string requestId, Guid Id, Guid actionId);

        Task<IResponse> GetStats(string requestId);
    }
}

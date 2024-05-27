using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper.Abstract;

namespace SocialNetwork.Business.Services.Abstract
{
    public interface IAdminService
    {
        Task<IResponse> GetUser(int pageSize, int pageNumber, string? searchString, OrderByEnum orderBy, bool isDescending);
        Task<IResponse> GetGroup(int pageSize, int pageNumber, string? searchString, OrderByEnum orderBy, bool isDescending);
        Task<IResponse> GetPost(int pageSize, int pageNumber, string? searchString);
        Task<IResponse> GetComment(int pageSize, int pageNumber, string? searchString);

        Task<IResponse> LockUserReport(string requestId, Guid reportId);
        Task<IResponse> UnLockUserReport(string requestId, Guid reportId);

        Task<IResponse> DeleteRelatedReport(string requestId, Guid reportId);
        Task<IResponse> UnDeleteRelatedReport(string requestId, Guid reportId);

        Task<IResponse> GetActionDid(string requestId, Guid reportId);

    }
}

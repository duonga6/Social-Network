using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Wrapper.Abstract;

namespace SocialNetwork.Business.Services.Abstract
{
    public interface IGroupInviteService
    {
        Task<IResponse> GetByGroup(string requestId, string? searchString, int pageSize, int pageNumber, Guid groupId);
        Task<IResponse> Create(string requestId, CreateGroupInviteRequest request);
        Task<IResponse> DeleteByGroup(string requestId, Guid groupId);
        Task<IResponse> Delete(string requestId, Guid id);
        Task<IResponse> AcceptRequest(string requestId, Guid id);
    }
}

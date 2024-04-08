using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Wrapper.Abstract;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IGroupInviteService
    {
        Task<IResponse> Create(string requestId, CreateGroupInviteRequest request);
        Task<IResponse> GetByGroup(string requestId, string? searchString, int pageSize, int pageNumber, Guid groupId);
        Task<IResponse> Delete(string requestId, Guid Id);
    }
}

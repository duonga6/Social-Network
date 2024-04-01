using SocialNetwork.Business.DTOs.Groups.Request;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IGroupService
    {
        Task<IResponse> Get(string requestId, string? searchString, int pageSize, int pageNumber);
        Task<IResponse> GetById(string requestId, Guid Id);
        Task<IResponse> Create(string requestId, CreateGroupRequest request);
        Task<IResponse> Update(string requestId, Guid Id, UpdateGroupRequest request);
        Task<IResponse> Delete(string requestId, Guid Id);
    }
}

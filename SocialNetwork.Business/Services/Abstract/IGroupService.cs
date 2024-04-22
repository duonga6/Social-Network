using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper.Abstract;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IGroupService
    {
        Task<IResponse> Get(string requestId, string? searchString, int pageSize, int pageNumber, GroupType type);
        Task<IResponse> GetById(string requestId, Guid Id);
        Task<IResponse> Create(string requestId, CreateGroupRequest request);
        Task<IResponse> Update(string requestId, Guid Id, UpdateGroupRequest request);
        Task<IResponse> Delete(string requestId, Guid Id);
        Task<IResponse> GetFeed(string requestId, int pageSize, DateTime? cursor);

        Task<IResponse> GetMedia(string requestId, Guid groupId, int pageSize, int pageNumber);

        Task<IResponse> GetPost(string requestId, Guid groupId, int pageSize, int pageNumber, string? searchString);
        Task<IResponse> GetPost(string requestId, Guid groupId, int pageSize, DateTime? cursor, string? searchString, bool getNext = true);
    }
}

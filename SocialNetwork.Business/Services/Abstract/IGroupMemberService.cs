using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Wrapper.Abstract;

namespace SocialNetwork.Business.Services.Abstract
{
    public interface IGroupMemberService
    {
        Task<IResponse> GetAll(string requestId, int pageSize, int pageNumber, string? searchString, Guid groupId);
        Task<IResponse> Delete(string requestId, Guid id);
        Task<IResponse> Delete(string requestId, Guid groupId, string userId);
        Task<IResponse> InviteUser(string requestId, CreateGroupMemberRequest request);
    }
}

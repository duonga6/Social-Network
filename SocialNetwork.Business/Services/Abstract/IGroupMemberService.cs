using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper.Abstract;

namespace SocialNetwork.Business.Services.Abstract
{
    public interface IGroupMemberService
    {
        Task<IResponse> GetAll(string requestId, int pageSize, int pageNumber, string? searchString, Guid groupId, MemberType memberType);
        Task<IResponse> GetCursor(string requestId, int pageSize, DateTime? cursor, string? searchString, Guid groupId);
        Task<IResponse> GetById(string requestId, Guid id);
        Task<IResponse> GetById(string requestId, Guid groupId, string userId);
        Task<IResponse> Delete(string requestId, Guid id);
        Task<IResponse> Delete(string requestId, Guid groupId, string userId);
        Task<IResponse> InviteUser(string requestId, CreateGroupMemberRequest request);

        Task<IResponse> CreateAdmin(string requestId, CreateGroupAdminRequest request);
        Task<IResponse> CreateAdmin(string requestId, Guid memberId);
        Task<IResponse> DeleteAdmin(string requestId, Guid groupId, string userId);
        Task<IResponse> DeleteAdmin(string requestId, Guid memberId);
    }
}

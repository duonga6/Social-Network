using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.Wrapper.Abstract;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<IResponse> GetAll(string? searchString, int pageSize, int pageNumber);
        Task<IResponse> GetById(string id);
        Task<IResponse> Register(RegistrationRequest request, string ipaddress);
        Task<IResponse> Login(LoginRequest request);
        Task<IResponse> RenewToken(RenewTokenRequest token);
        Task<IResponse> ForgotPassword(ForgotPasswordRequest request);
        Task<IResponse> ResetPassword(ResetPasswordRequest request);
        Task<IResponse> UpdateInfo(string loggedUserId, string requestUserId, UpdateUserInfoRequest request);
        Task<IResponse> DeleteUser(string loggedUserId, string requestUserId);
        Task<IResponse> ConfirmEmail(ConfirmEmailRequest request);
        Task<IResponse> ResendConfirmEmail(ResendConfirmEmailRequest request);
        Task<IResponse> ChangePassword(string requestUserId, ChangePasswordRequest request);
        Task<IResponse> GetPhoto(string requestUserId, string targetUserId, int pageSize, int pageNumber);
        Task<IResponse> ChangeCoverImage(string requestId, ChangeCoverImageRequest request);
        Task<IResponse> ChangeAvatar(string requestId, ChangeCoverImageRequest request);
        Task<IResponse> FindByEmail(string requestId, string email);
        Task<IResponse> LockOut(string requestId, string targetId);
        Task<IResponse> UnLockOut(string requestId, string targetId);

        Task<IResponse> AddRoles(string userId, AddRolesToUserRequest request);
        Task<IResponse> UpdateRole(string userId, AddRolesToUserRequest request);
        Task<IResponse> GetRoles(string userId);


        Task<IResponse> GetPostById(string loggedUserId ,string requestUserId, Guid postId);
        Task<IResponse> GetPostByUser(string loggedUserId, string requestUserId, string? searchString, int pageSize, int pageNumber);
        Task<IResponse> GetPostCursor(string loggedUserId, string requestUserId, string? searchString, int pageSize, DateTime? cursor);
        Task<IResponse> CreatePost(string loggedUserId, string requestUserId, CreatePostRequest request);
        Task<IResponse> DeletePost(string loggedUserId, string requestUserId, Guid postId);
        Task<IResponse> UpdatePost(string loggedUserId, string requestUserId, Guid postId, UpdatePostRequest request);

        Task<IResponse> GetNotifications(string loggedUserId, string requestUserId, string? searchString, int pageSize, int pageNumber);
        Task<IResponse> GetNotificationsById(string loggedUserId, string requestUserId, Guid id);
        Task<IResponse> SeenNotifications(string loggedUserId, string requestUserId, Guid id);

        Task<IResponse> GetFriends(string requestUserId, string targetUserId, int pageSize, int pageNumber, string? searchString);

        Task<IResponse> AddRole(string requestUserId, string targetUserId,CreateUserRoleRequest request);
        Task<IResponse> RemoveRole(string requestUserId, string targetUserId,CreateUserRoleRequest request);


        Task<IResponse> Stats(string requestUserId);
    }
}

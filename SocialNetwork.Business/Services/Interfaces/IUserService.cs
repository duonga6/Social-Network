using SocialNetwork.Business.DTOs.Friendship.Requests;
using SocialNetwork.Business.DTOs.Message.Requests;
using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.DTOs.Token.Requests;
using SocialNetwork.Business.DTOs.User.Requests;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper.Interfaces;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<IResponse> GetAll(string? searchString, int pageSize, int pageNumber);
        Task<IResponse> GetById(string loggedUserId, string requestUserId);
        Task<IResponse> Register(RegistrationRequest request);
        Task<IResponse> Login(LoginRequest request);
        Task<IResponse> RenewToken(RenewTokenRequest token);
        Task<IResponse> ForgotPassword(ForgotPasswordRequest request);
        Task<IResponse> ResetPassword(ResetPasswordRequest request);
        Task<IResponse> UpdateInfo(string loggedUserId, string requestUserId, UpdateUserInfoRequest request);
        Task<IResponse> DeleteUser(string loggedUserId, string requestUserId);
        Task<IResponse> ConfirmEmail(ConfirmEmailRequest request);
        Task<IResponse> ResendConfirmEmail(ResendConfirmEmailRequest request);
        Task<IResponse> ChangePassword(string loggedUserId, ChangePasswordRequest request);


        Task<IResponse> AddRoles(string userId, AddRolesToUserRequest request);
        Task<IResponse> UpdateRole(string userId, AddRolesToUserRequest request);
        Task<IResponse> GetRoles(string userId);


        Task<IResponse> GetPostById(string loggedUserId ,string requestUserId, Guid postId);
        Task<IResponse> GetPostByUser(string loggedUserId, string requestUserId, string? searchString, int pageSize, int pageNumber);
        Task<IResponse> CreatePost(string loggedUserId, string requestUserId, CreatePostRequest request);
        Task<IResponse> DeletePost(string loggedUserId, string requestUserId, Guid postId);
        Task<IResponse> UpdatePost(string loggedUserId, string requestUserId, Guid postId, UpdatePostRequest request);

        Task<IResponse> AddFriend(string loggedUserId, string requestUserId, BaseFriendRequest request);
        Task<IResponse> UnFriend(string loggedUserId, string requestUserId, string targetUserId);
        Task<IResponse> CancelRequest(string loggedUserId, string requestUserId, string targetUserId);
        Task<IResponse> AcceptRequest(string loggedUserId, string requestUserId, string targetUserId);
        Task<IResponse> RefuseRequest(string loggedUserId, string requestUserId, string targetUserId);
        Task<IResponse> BlockFriend(string loggedUserId, string requestUserId, BaseFriendRequest request);
        Task<IResponse> UnBlockFriend(string loggedUserId, string requestUserId, string targetUserId);
        Task<IResponse> GetFriendshipByUser(string loggedUserId, string requestUserId, string? searchString, int pageSize, int pageNumber, FriendType type);
        Task<IResponse> GetFriendshipById(string loggedUserId, string requestUserId, Guid id);

        Task<IResponse> SendMessage(string loggedUserId, string requestUserId, SendMessageRequest request);
        Task<IResponse> GetConversation(string loggedUserId, string requestUserId, string targetUserId, string? searchString, int pageSize, int pageNumber);
        Task<IResponse> GetMessageById(string loggedUserId, string requestUserId, Guid id);
        Task<IResponse> DeleteMessage(string loggedUserId, string requestUserId, Guid id);

        Task<IResponse> GetNotifications(string loggedUserId, string requestUserId, string? searchString, int pageSize, int pageNumber);
        Task<IResponse> GetNotificationsById(string loggedUserId, string requestUserId, Guid id);
        Task<IResponse> SeenNotifications(string loggedUserId, string requestUserId, Guid id);
    }
}

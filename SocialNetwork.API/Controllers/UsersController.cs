using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.DTOs.Friendship.Requests;
using SocialNetwork.Business.DTOs.Message.Requests;
using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.DTOs.Token.Requests;
using SocialNetwork.Business.DTOs.User.Requests;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Utilities.Roles;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        #region Auth + Info
        /// <summary>
        /// Register
        /// </summary>
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IResponse> Register(RegistrationRequest request)
        {
            return await _userService.Register(request);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IResponse> Login(LoginRequest request)
        {
            return await _userService.Login(request);
        }

        /// <summary>
        /// Forgot password: return code reset
        /// </summary>
        [HttpPost("ForgotPassword")]
        [AllowAnonymous]
        public async Task<IResponse> ForgotPassword(ForgotPasswordRequest request)
        {
            return await _userService.ForgotPassword(request);
        }

        /// <summary>
        /// Reset password: code from ForgotPassword
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<IResponse> ResetPassword(ResetPasswordRequest request)
        {
            return await _userService.ResetPassword(request);
        }

        /// <summary>
        /// Get code confirm email
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CodeConfirmEmail")]
        [AllowAnonymous]
        public async Task<IResponse> ResendConfirmEmail(ResendConfirmEmailRequest request)
        {
            return await _userService.ResendConfirmEmail(request);
        }

        /// <summary>
        /// Confirm email: code from ResendConfirmEmail
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ConfirmEmail")]
        [AllowAnonymous]
        public async Task<IResponse> ConfirmEmail(ConfirmEmailRequest request)
        {
            return await _userService.ConfirmEmail(request);
        }

        /// <summary>
        /// New token
        /// </summary>
        [HttpPost("RenewToken")]
        [AllowAnonymous]
        public async Task<IResponse> RenewToken(RenewTokenRequest token)
        {
            return await _userService.RenewToken(token);
        }

        /// <summary>
        /// Get all user's info
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = RoleName.Administrator)]
        public async Task<IResponse> GetAll()
        {
            return await _userService.GetAll();
        }

        /// <summary>
        /// User info
        /// </summary>
        [HttpGet("{Id}")]
        public async Task<IResponse> GetById(string Id)
        {
            return await _userService.GetById(UserId, Id);
        }

        /// <summary>
        /// Update user info
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<IResponse> UpdateUser(string Id, UpdateUserInfoRequest request)
        {
            return await _userService.UpdateInfo(UserId, Id, request);
        }

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IResponse> DeleteUser(string Id)
        {
            return await _userService.DeleteUser(UserId, Id);
        }

        #endregion

        #region Post

        /// <summary>
        /// User create post
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Posts")]
        public async Task<IResponse> CreatePost(string Id, CreatePostRequest request)
        {
            return await _userService.CreatePost(UserId, Id, request);
        }

        /// <summary>
        /// User delete post
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Posts/{postId:guid}")]
        public async Task<IResponse> DeletePost(string Id, Guid postId)
        {
            return await _userService.DeletePost(UserId, Id, postId);
        }

        /// <summary>
        /// Get post of user by postid
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Posts/{postId:guid}")]
        public async Task<IResponse> GetPostById(string Id, Guid postId)
        {
            return await _userService.GetPostById(UserId, Id, postId);
        }

        /// <summary>
        /// Get all posts by userId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Posts")]
        public async Task<IResponse> GetPostByUser(string Id)
        {
            return await _userService.GetPostByUser(UserId, Id);
        }

        /// <summary>
        /// User update post
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="postId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}/Posts/{postId:guid}")]
        public async Task<IResponse> UpdatePost(string Id, Guid postId, UpdatePostRequest request)
        {
            return await _userService.UpdatePost(UserId, Id, postId, request);
        }

        #endregion

        #region Friendship

        /// <summary>
        /// Get friendship of user
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Friendship")]
        public async Task<IResponse> GetFriendship(string Id)
        {
            return await _userService.GetFriendshipByUser(UserId, Id);
        }

        /// <summary>
        /// Send friend invitations
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Friendship/AddFriend")]
        public async Task<IResponse> AddFriend(string Id, [FromBody] BaseFriendRequest request)
        {
            return await _userService.AddFriend(UserId, Id, request);
        }

        /// <summary>
        /// Unfriend
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="targetUserId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Friendship/UnFriend/{targetUserId}")]
        public async Task<IResponse> UnFriend(string Id, string targetUserId)
        {
            return await _userService.UnFriend(UserId, Id, targetUserId);
        }

        /// <summary>
        /// Cancel friend request
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="targetUserId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Friendship/CancelAddFriendRequest/{targetUserId}")]
        public async Task<IResponse> CancelFriendRequest(string Id, string targetUserId)
        {
            return await _userService.CancelRequest(UserId, Id, targetUserId);
        }

        /// <summary>
        /// Accept friend request
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="targetUserId"></param>
        /// <returns></returns>
        [HttpPut("{Id}/Friendship/AcceptFriend/{targetUserId}")]
        public async Task<IResponse> AcceptFriend(string Id, string targetUserId)
        {
            return await _userService.AcceptRequest(UserId, Id, targetUserId);
        }

        /// <summary>
        /// Refuse friend requests
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="targetUserId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Friendship/RefuseFriend/{targetUserId}")]
        public async Task<IResponse> RefuesFriend(string Id, string targetUserId)
        {
            return await _userService.RefuseRequest(UserId, Id, targetUserId);
        }

        /// <summary>
        /// Block friend
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Friendship/BlockFriend")]
        public async Task<IResponse> BlockFriend(string Id, [FromBody] BaseFriendRequest request)
        {
            return await _userService.BlockFriend(UserId, Id, request);
        }

        /// <summary>
        /// Unblock friend
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="targetUserId"></param>
        /// <returns></returns>
        [HttpPut("{Id}/Friendship/UnBlockFriend/{targetUserId}")]
        public async Task<IResponse> UnBlockFriend(string Id, string targetUserId)
        {
            return await _userService.UnBlockFriend(UserId, Id, targetUserId);
        }

        #endregion

        #region Messages

        /// <summary>
        /// Get message conversation with target user
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="targetUserId"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Messages/{targetUserId}")]
        public async Task<IResponse> GetConversation(string Id, string targetUserId)
        {
            return await _userService.GetConversation(UserId, Id, targetUserId);
        }

        /// <summary>
        /// Send message to user
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Messages")]
        public async Task<IResponse> SendMessage(string Id, [FromBody] SendMessageRequest request)
        {
            return await _userService.SendMessage(UserId, Id, request); 
        }

        /// <summary>
        /// Delete message
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Messages/{messageId}")]
        public async Task<IResponse> DeleteMessage(string Id, Guid messageId)
        {
            return await _userService.DeleteMessage(UserId, Id, messageId);
        }

        #endregion

        #region Notification

        /// <summary>
        /// Get notifications
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Notifications")]
        public async Task<IResponse> GetNotifications(string Id)
        {
            return await _userService.GetNotifications(UserId, Id);
        }

        /// <summary>
        /// Get notification by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Notifications/{notificationId}")]
        public async Task<IResponse> GetNotificationById(string Id, Guid notificationId)
        {
            return await _userService.GetNotificationsById(UserId, Id, notificationId);
        }

        /// <summary>
        /// Seen notification
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        [HttpPut("{Id}/Notifications/{notificationId}")]
        public async Task<IResponse> SeenNotification(string Id, Guid notificationId)
        {
            return await _userService.SeenNotifications(UserId, Id, notificationId);
        }


        #endregion
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.Friendship.Requests;
using SocialNetwork.Business.DTOs.Friendship.Responses;
using SocialNetwork.Business.DTOs.Message.Requests;
using SocialNetwork.Business.DTOs.Message.Responses;
using SocialNetwork.Business.DTOs.Notification.Responses;
using SocialNetwork.Business.DTOs.Post.Requests;
using SocialNetwork.Business.DTOs.Post.Responses;
using SocialNetwork.Business.DTOs.Token;
using SocialNetwork.Business.DTOs.Token.Requests;
using SocialNetwork.Business.DTOs.Users.Requests;
using SocialNetwork.Business.DTOs.Users.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using SocialNetwork.DataAccess.Utilities.Roles;
using System.ComponentModel.DataAnnotations;

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
        [ProducesResponseType(typeof(DataResponse<UserWithTokenResponse>), 200)]
        public async Task<IResponse> Register([FromBody] RegistrationRequest request)
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
        [ProducesResponseType(typeof(DataResponse<UserWithTokenResponse>), 200)]
        public async Task<IResponse> Login([FromBody] LoginRequest request)
        {
            return await _userService.Login(request);
        }

        /// <summary>
        /// Forgot password: return code reset
        /// </summary>
        [HttpPost("ForgotPassword")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(DataResponse<ForgotPasswordCodeResponse>), 200)]
        public async Task<IResponse> ForgotPassword([FromBody] ForgotPasswordRequest request)
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
        [ProducesResponseType(typeof(DataResponse<Token>), 200)]
        public async Task<IResponse> ResetPassword([FromBody] ResetPasswordRequest request)
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
        [ProducesResponseType(typeof(DataResponse<ResendConfirmEmailResponse>), 200)]
        public async Task<IResponse> ResendConfirmEmail([FromBody] ResendConfirmEmailRequest request)
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
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> ConfirmEmail([FromBody] ConfirmEmailRequest request)
        {
            return await _userService.ConfirmEmail(request);
        }

        /// <summary>
        /// New token
        /// </summary>
        [HttpPost("RenewToken")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(DataResponse<Token>), 200)]
        public async Task<IResponse> RenewToken([FromBody] RenewTokenRequest token)
        {
            return await _userService.RenewToken(token);
        }

        /// <summary>
        /// Get all user's info
        /// </summary>
        /// <param name="searchString">Search name</param>
        /// <param name="pageSize">Item count per page</param>
        /// <param name="pageNumber">Current page</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = RoleName.Administrator)]
        [ProducesResponseType(typeof(PagedResponse<List<GetUserResponse>>), 200)]
        public async Task<IResponse> GetAll(string? searchString,[FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return await _userService.GetAll(searchString, pageSize, pageNumber);
        }

        /// <summary>
        /// Get logged user info
        /// </summary>
        /// <returns></returns>
        [HttpGet("Info")]
        [ProducesResponseType(typeof(DataResponse<GetUserResponse>), 200)]
        public async Task<IResponse> GetInfo()
        {
            return await _userService.GetById(UserId, UserId);
        }

        /// <summary>
        /// User info
        /// </summary>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetUserResponse>), 200)]
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
        [ProducesResponseType(typeof(DataResponse<GetUserResponse>), 200)]
        public async Task<IResponse> UpdateUser(string Id, [FromBody] UpdateUserInfoRequest request)
        {
            return await _userService.UpdateInfo(UserId, Id, request);
        }

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> DeleteUser(string Id)
        {
            return await _userService.DeleteUser(UserId, Id);
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ChangePassword")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            return await _userService.ChangePassword(UserId, request);
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
        [ProducesResponseType(typeof(DataResponse<GetPostResponse>), 200)]
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
        [ProducesResponseType(typeof(SuccessResponse), 200)]
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
        [ProducesResponseType(typeof(DataResponse<GetPostResponse>), 200)]
        public async Task<IResponse> GetPostById(string Id, Guid postId)
        {
            return await _userService.GetPostById(UserId, Id, postId);
        }

        /// <summary>
        /// Get all posts by userId
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="searchString"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Posts")]
        [ProducesResponseType(typeof(PagedResponse<List<GetPostResponse>>), 200)]
        public async Task<IResponse> GetPostByUser(string Id,[FromQuery] string? searchString,[FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return await _userService.GetPostByUser(UserId, Id, searchString, pageSize, pageNumber);
        }

        /// <summary>
        /// User update post
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="postId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}/Posts/{postId:guid}")]
        [ProducesResponseType(typeof(DataResponse<GetPostResponse>), 200)]
        public async Task<IResponse> UpdatePost(string Id, Guid postId, UpdatePostRequest request)
        {
            return await _userService.UpdatePost(UserId, Id, postId, request);
        }

        #endregion

        #region Friendship

        /// <summary>
        /// Get friendship of user
        /// </summary>
        /// <param name="Id">User id</param>
        /// <param name="searchString">Search by name</param>
        /// <param name="pageSize">Item per page</param>
        /// <param name="pageNumber">Current page</param>
        /// <param name="type">Type friend to get 0: all, 1: pending from me, 2: pending from other, 3: accepted, 4: blocked</param>
        /// <returns></returns>
        [HttpGet("{Id}/Friendship")]
        [ProducesResponseType(typeof(PagedResponse<List<GetFriendshipResponse>>), 200)]
        public async Task<IResponse> GetFriendship(string Id, string? searchString, [FromQuery, Required] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber, [FromQuery, Required, Range(1, int.MaxValue)] FriendType type)
        {   
            return await _userService.GetFriendshipByUser(UserId, Id, searchString, pageSize, pageNumber, type);
        }

        /// <summary>
        /// Get friendship by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="friendshipId"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Friendship/{friendshipId}")]
        [ProducesResponseType(typeof(DataResponse<GetFriendshipResponse>), 200)]
        public async Task<IResponse> GetFriendshipById(string Id, Guid friendshipId)
        {
            return await _userService.GetFriendshipById(UserId, Id, friendshipId);
        }

        /// <summary>
        /// Send friend invitations
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Friendship/AddFriend")]
        [ProducesResponseType(typeof(DataResponse<GetFriendshipResponse>), 200)]
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
        [ProducesResponseType(typeof(SuccessResponse), 200)]
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
        [ProducesResponseType(typeof(SuccessResponse), 200)]
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
        [ProducesResponseType(typeof(SuccessResponse), 200)]
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
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> RefuseFriend(string Id, string targetUserId)
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
        [ProducesResponseType(typeof(SuccessResponse), 200)]
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
        [ProducesResponseType(typeof(SuccessResponse), 200)]
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
        /// <param name="searchString">Key word search message</param>
        /// <param name="pageSize">Item per page</param>
        /// <param name="pageNumber">Current page</param>
        /// <returns></returns>
        [HttpGet("{Id}/Messages")]
        [ProducesResponseType(typeof(PagedResponse<List<GetMessageResponse>>), 200)]
        public async Task<IResponse> GetConversation(string Id,[FromQuery, Required] string targetUserId, [FromQuery] string? searchString, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return await _userService.GetConversation(UserId, Id, targetUserId, searchString, pageSize, pageNumber);
        }

        /// <summary>
        /// Get message by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Messages/{messageId}")]
        [ProducesResponseType(typeof(DataResponse<GetMessageResponse>), 200)]
        public async Task<IResponse> GetMessageById(string Id, Guid messageId)
        {
            return await _userService.GetMessageById(UserId, Id, messageId);
        }
       
        /// <summary>
        /// Send message to user
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{Id}/Messages")]
        [ProducesResponseType(typeof(DataResponse<GetMessageResponse>), 200)]
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
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IResponse> DeleteMessage(string Id, Guid messageId)
        {
            return await _userService.DeleteMessage(UserId, Id, messageId);
        }

        #endregion

        #region Notification

        /// <summary>
        /// Get notifications
        /// </summary>
        /// <param name="Id">Id of user</param>
        /// <param name="searchString">Key word search</param>
        /// <param name="pageSize">Item count per page</param>
        /// <param name="pageNumber">Current page</param>
        /// <returns></returns>
        [HttpGet("{Id}/Notifications")]
        [ProducesResponseType(typeof(PagedResponse<List<GetNotificationResponse>>), 200)]
        public async Task<IResponse> GetNotifications(string Id,[FromQuery] string? searchString, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return await _userService.GetNotifications(UserId, Id, searchString, pageSize, pageNumber);
        }

        /// <summary>
        /// Get notification by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Notifications/{notificationId}")]
        [ProducesResponseType(typeof(DataResponse<GetNotificationResponse>), 200)]
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
        [ProducesResponseType(typeof(DataResponse<GetNotificationResponse>), 200)]
        public async Task<IResponse> SeenNotification(string Id, Guid notificationId)
        {
            return await _userService.SeenNotifications(UserId, Id, notificationId);
        }

        #endregion
    }
}

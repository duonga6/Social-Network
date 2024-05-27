using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.Requests;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Abstract;
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
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            return ResponseModel(await _userService.Register(request, HttpContext.Connection.RemoteIpAddress?.ToString()));
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(DataResponse<UserWithTokenResponse>), 200)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            return ResponseModel(await _userService.Login(request));
        }

        /// <summary>
        /// Forgot password: return code reset
        /// </summary>
        [HttpPost("ForgotPassword")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(DataResponse<ForgotPasswordCodeResponse>), 200)]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            return ResponseModel(await _userService.ForgotPassword(request));
        }

        /// <summary>
        /// Reset password: code from ForgotPassword
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(DataResponse<UserWithTokenResponse>), 200)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            return ResponseModel(await _userService.ResetPassword(request));
        }

        /// <summary>
        /// Get code confirm email
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CodeConfirmEmail")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(DataResponse<ResendConfirmEmailResponse>), 200)]
        public async Task<IActionResult> ResendConfirmEmail([FromBody] ResendConfirmEmailRequest request)
        {
            return ResponseModel(await _userService.ResendConfirmEmail(request));
        }

        /// <summary>
        /// Confirm email: code from ResendConfirmEmail
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ConfirmEmail")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(DataResponse<UserWithTokenResponse>), 200)]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailRequest request)
        {
            return ResponseModel(await _userService.ConfirmEmail(request));
        }

        /// <summary>
        /// New token
        /// </summary>
        [HttpPost("RenewToken")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(DataResponse<Token>), 200)]
        public async Task<IActionResult> RenewToken([FromBody] RenewTokenRequest token)
        {
            return ResponseModel(await _userService.RenewToken(token));
        }

        /// <summary>
        /// Get all user's info
        /// </summary>
        /// <param name="searchString">Search name</param>
        /// <param name="pageSize">Item count per page</param>
        /// <param name="pageNumber">Current page</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<List<GetUserResponse>>), 200)]
        public async Task<IActionResult> GetAll(string? searchString,[FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return ResponseModel(await _userService.GetAll(searchString, pageSize, pageNumber));
        }

        /// <summary>
        /// Get logged user info
        /// </summary>
        /// <returns></returns>
        [HttpGet("Info")]
        [ProducesResponseType(typeof(DataResponse<GetUserResponse>), 200)]
        public async Task<IActionResult> GetInfo()
        {
            return ResponseModel(await _userService.GetById(UserId));
        }

        /// <summary>
        /// User info
        /// </summary>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetUserResponse>), 200)]
        public async Task<IActionResult> GetById(string Id)
        {
            return ResponseModel(await _userService.GetById(Id));
        }

        /// <summary>
        /// Get user's photo contain in post
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [HttpGet("{Id}/GetPhotos")]
        [ProducesResponseType(typeof(PagedResponse<List<GetPostMediaResponse>>), 200)]
        public async Task<IActionResult> GetPhotos(string Id, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return ResponseModel(await _userService.GetPhoto(UserId, Id, pageSize, pageNumber));
        }

        /// <summary>
        /// Update user info
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetUserResponse>), 200)]
        public async Task<IActionResult> UpdateUser(string Id, [FromBody] UpdateUserInfoRequest request)
        {
            return ResponseModel(await _userService.UpdateInfo(UserId, Id, request));
        }

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            return ResponseModel(await _userService.DeleteUser(UserId, Id));
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("ChangePassword")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            return ResponseModel(await _userService.ChangePassword(UserId, request));
        }

        /// <summary>
        /// Change cover image
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("CoverImage")]
        [ProducesResponseType(typeof(DataResponse<GetUserResponse>), 200)]
        public async Task<IActionResult> ChangeCoverImage([FromBody] ChangeCoverImageRequest request)
        {
            return ResponseModel(await _userService.ChangeCoverImage(UserId, request));
        }

        /// <summary>
        /// Change avatar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("Avatar")]
        [ProducesResponseType(typeof(DataResponse<BasicUserResponse>), 200)]
        public async Task<IActionResult> ChangeAvatar([FromBody] ChangeCoverImageRequest request)
        {
            return ResponseModel(await _userService.ChangeAvatar(UserId, request));
        }

        /// <summary>
        /// Find user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("FindByEmail")]
        [ProducesResponseType(typeof(DataResponse<GetUserResponse>), 200)]
        public async Task<IActionResult> FindByEmail([FromQuery, Required] string email)
        {
            return ResponseModel(await _userService.FindByEmail(UserId, email));
        }

        /// <summary>
        /// Add role to user
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = RoleName.Administrator)]
        [HttpPost("{Id}/Roles")]
        [ProducesResponseType(typeof(SuccessResponse),201)]
        public async Task<IActionResult> AddRoles(string Id, [FromBody] CreateUserRoleRequest request)
        {
            return ResponseModel(await _userService.AddRole(UserId, Id, request));
        }

        /// <summary>
        /// Remove role to user
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = RoleName.Administrator)]
        [HttpPut("{Id}/Roles")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> RemoveRoles(string Id, [FromBody] CreateUserRoleRequest request)
        {
            return ResponseModel(await _userService.RemoveRole(UserId, Id, request));
        }

        /// <summary>
        /// Lock a user
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize(Roles = RoleName.Administrator)]
        [HttpPost("{Id}/Lockout")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> LockOut(string Id)
        {
            return ResponseModel(await _userService.LockOut(UserId, Id));
        }

        /// <summary>
        /// UnLock a user
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize(Roles = RoleName.Administrator)]
        [HttpPost("{Id}/UnLockout")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> UnLockOut(string Id)
        {
            return ResponseModel(await _userService.UnLockOut(UserId, Id));
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
        public async Task<IActionResult> CreatePost(string Id, CreatePostRequest request)
        {
            return ResponseModel(await _userService.CreatePost(UserId, Id, request));
        }

        /// <summary>
        /// User delete post
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/Posts/{postId:guid}")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        public async Task<IActionResult> DeletePost(string Id, Guid postId)
        {
            return ResponseModel(await _userService.DeletePost(UserId, Id, postId));
        }

        /// <summary>
        /// Get post of user by postid
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Posts/{postId:guid}")]
        [ProducesResponseType(typeof(DataResponse<GetPostResponse>), 200)]
        public async Task<IActionResult> GetPostById(string Id, Guid postId)
        {
            return ResponseModel(await _userService.GetPostById(UserId, Id, postId));
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
        public async Task<IActionResult> GetPost(string Id,[FromQuery] string? searchString,[FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return ResponseModel(await _userService.GetPostByUser(UserId, Id, searchString, pageSize, pageNumber));
        }

        /// <summary>
        /// Get all post by user id by cursor
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="searchString"></param>
        /// <param name="pageSize"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Posts/Cursor")]
        [ProducesResponseType(typeof(CursorResponse<List<GetPostResponse>>), 200)]
        public async Task<IActionResult> GetPostCursor(string Id, [FromQuery] string? searchString, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, DateTime? cursor)
        {
            return ResponseModel(await _userService.GetPostCursor(UserId, Id, searchString, pageSize, cursor));
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
        public async Task<IActionResult> UpdatePost(string Id, Guid postId, UpdatePostRequest request)
        {
            return ResponseModel(await _userService.UpdatePost(UserId, Id, postId, request));
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
        public async Task<IActionResult> GetNotifications(string Id,[FromQuery] string? searchString, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return ResponseModel(await _userService.GetNotifications(UserId, Id, searchString, pageSize, pageNumber));
        }

        /// <summary>
        /// Get notification by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Notifications/{notificationId}")]
        [ProducesResponseType(typeof(DataResponse<GetNotificationResponse>), 200)]
        public async Task<IActionResult> GetNotificationById(string Id, Guid notificationId)
        {
            return ResponseModel(await _userService.GetNotificationsById(UserId, Id, notificationId));
        }

        /// <summary>
        /// Seen notification
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        [HttpPut("{Id}/Notifications/{notificationId}")]
        [ProducesResponseType(typeof(DataResponse<GetNotificationResponse>), 200)]
        public async Task<IActionResult> SeenNotification(string Id, Guid notificationId)
        {
            return ResponseModel(await _userService.SeenNotifications(UserId, Id, notificationId));
        }

        #endregion

        #region Friend

        /// <summary>
        /// Get friend of user
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="searchString"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [HttpGet("{Id}/Friendships")]
        [ProducesResponseType(typeof(PagedResponse<List<GetFriendshipResponse>>), 200)]
        public async Task<IActionResult> GetFriends(string Id, [FromQuery] string? searchString, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return ResponseModel(await _userService.GetFriends(UserId, Id, pageSize, pageNumber, searchString));
        }

        #endregion

        /// <summary>
        /// Get stats of user
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles = RoleName.Administrator)]
        [HttpGet("Stats")]
        [ProducesResponseType(typeof(DataResponse<StatsUserResponse>), 200)]
        public async Task<IActionResult> GetStats()
        {
            return ResponseModel(await _userService.Stats(UserId));
        }
    }
}

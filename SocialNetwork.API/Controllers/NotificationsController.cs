using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Controllers.Base;
using SocialNetwork.Business.DTOs.Message.Responses;
using SocialNetwork.Business.DTOs.Notification.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper;
using SocialNetwork.Business.Wrapper.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.API.Controllers
{
    [Authorize]
    public class NotificationsController : BaseController
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        /// <summary>
        /// Get all notification of user
        /// </summary>
        /// <param name="searchString">Key word search</param>
        /// <param name="pageSize">Item count per page</param>
        /// <param name="pageNumber">Current page</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<List<GetNotificationResponse>>), 200)]
        public async Task<IResponse> GetAll([FromQuery] string? searchString, [FromQuery, Required, Range(1, int.MaxValue)] int pageSize, [FromQuery, Required, Range(1, int.MaxValue)] int pageNumber)
        {
            return await _notificationService.GetNotifications(UserId, searchString, pageSize, pageNumber);
        }


        /// <summary>
        /// Get notification of user by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetNotificationResponse>), 200)]
        public async Task<IResponse> GetById(Guid Id)
        {
            return await _notificationService.GetById(UserId, Id);
        }

        /// <summary>
        /// Seen notification
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost("{Id}")]
        [ProducesResponseType(typeof(DataResponse<GetNotificationResponse>), 200)]
        public async Task<IResponse> SeenNotification(Guid Id)
        {
            return await _notificationService.SeenNotification(UserId, Id);
        }

        /// <summary>
        /// Get user's notification with cursor pagnigaion
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="endCursor"></param>
        /// <param name="getNext"></param>
        /// <returns></returns>
        [HttpGet("GetCursor")]
        [ProducesResponseType(typeof(CursorResponse<List<GetNotificationResponse>>), 200)]
        public async Task<IResponse> GetCursor([FromQuery, Required, Range(1, int.MaxValue)] int pageSize, DateTime? endCursor, bool getNext = true)
        {
            return await _notificationService.GetCursor(UserId, pageSize, endCursor, getNext);
        }
        
    }
}

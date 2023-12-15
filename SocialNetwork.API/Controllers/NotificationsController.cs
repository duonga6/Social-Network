using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Wrapper.Interfaces;

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
        /// <returns></returns>
        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            return await _notificationService.GetNotifications(UserId);
        }


        /// <summary>
        /// Get notification of user by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<IResponse> GetById(Guid Id)
        {
            return await _notificationService.GetById(UserId, Id);
        }

        /// <summary>
        /// Seen notification
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<IResponse> SeenNotification(Guid Id)
        {
            return await _notificationService.SeenNotification(UserId, Id);
        }
    }
}

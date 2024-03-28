using SocialNetwork.Business.DTOs.Notification.Responses;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IHubControl
    {
        Task NewNotification(string userId, GetNotificationResponse notification);
    }
}

using SocialNetwork.Business.DTOs.Responses;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IHubControl
    {
        Task NewNotification(string userId, GetNotificationResponse notification);
        Task NewMessage(List<string> userIds, GetMessageResponse message);
        Task ChangeConversationName(List<string> userIds, GetConversationResponse conversation);
    }
}

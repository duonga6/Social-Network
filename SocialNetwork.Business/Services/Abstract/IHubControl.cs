using SocialNetwork.Business.DTOs.Responses;

namespace SocialNetwork.Business.Services.Interfaces
{
    public interface IHubControl
    {
        Task NewNotification(string userId, GetNotificationResponse notification);
        Task NewMessage(ICollection<string> userIds, GetMessageResponse message);
        Task ChangeConversationName(ICollection<string> userIds, GetConversationResponse conversation);
        Task NewGroupConversation(ICollection<string> userIds, GetConversationResponse conversation);
        Task DeleteConversation(ICollection<string> userIds, Guid conversationId);
        Task FriendIsActive(ICollection<string> userIds, string userId);
        Task FriendIsInActive(ICollection<string> userIds, string userId);
        List<string>? GetFriendActive(string userId);
    }
}

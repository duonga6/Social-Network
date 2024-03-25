using SocialNetwork.Business.DTOs.Users.Responses;

namespace SocialNetwork.Business.DTOs.Notification.Responses
{
    public class GetNotificationResponse
    {
        public Guid Id { get; set; }
        public DateTime? ReadAt { set; get; }
        public DateTime CreatedAt { set; get; }
        public string NotificationType { set; get; } = string.Empty;
        public string Content { set; get; } = string.Empty;
        public string JsonDetail { set; get; } = string.Empty;
        public BasicUserResponse FromUser { set; get; } = null!;
    }
}

namespace SocialNetwork.Business.DTOs.Notification.Responses
{
    public class GetNotificationResponse
    {
        public Guid Id { get; set; }
        public NotificationUser FromUser { get; set; } = null!;
        public string Content { get; set; } = string.Empty;
        public bool Seen { get; set; }
    }

    public class NotificationUser
    {
        public string Id { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
    }

}

namespace SocialNetwork.Business.DTOs.Notification.Responses
{
    public class GetNotificationResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool Seen { get; set; }
    }
}

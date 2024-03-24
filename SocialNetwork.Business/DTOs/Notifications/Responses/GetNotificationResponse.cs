using SocialNetwork.Business.DTOs.Notifications.Responses;

namespace SocialNetwork.Business.DTOs.Notification.Responses
{
    public class GetNotificationResponse
    {
        public Guid Id { get; set; }
        public DateTime? ReadAt { set; get; }
        public string NotifiableType { set; get; } = string.Empty;
        public Guid NotifiableId { set; get; }
        public GetNotificationDetailResponse Detail { set; get; } = null!;
    }
}

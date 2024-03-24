using SocialNetwork.Business.DTOs.Users.Responses;

namespace SocialNetwork.Business.DTOs.Notifications.Responses
{
    public class GetNotificationDetailResponse
    {
        public Guid Id { set; get; }
        public string Content { set; get; } = string.Empty;
        public string Url { set; get; } = string.Empty;
        public BasicUserResponse User { set; get; } = null!;
    }
}

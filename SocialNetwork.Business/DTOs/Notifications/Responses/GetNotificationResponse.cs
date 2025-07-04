﻿namespace SocialNetwork.Business.DTOs.Responses
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
        public string ToId { set; get; } = string.Empty;
    }
}

﻿namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetGroupResponse
    {
        public Guid Id { set; get; }
        public string Name { set; get; } = string.Empty;
        public string Description { set; get; } = string.Empty;
        public string CoverImage { set; get; } = string.Empty;
        public BasicUserResponse User { set; get; } = null!;
        public bool IsPublic { set; get; }
        public int TotalMember { set; get; }
        public bool PreCensored { set; get; }
        public DateTime CreatedAt { set; get; }
    }
}

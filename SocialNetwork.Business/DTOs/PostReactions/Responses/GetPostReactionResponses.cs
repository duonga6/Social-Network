﻿namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetPostReactionResponses
    {
        public List<PostReactionDetail> Reactions { set; get; } = new();
        public DataAccess.Entities.Reaction UserReacted { set; get; } = null!;
    }

    public class PostReactionDetail
    {
        public int Id { set; get; }
        public string Name { set; get; } = string.Empty;
        public string IconUrl { set; get; } = string.Empty;
        public string ColorCode { set; get; } = string.Empty;
        public List<BasicUserResponse> Users { set; get; } = new();
        public int Total { set; get; }
    }
}

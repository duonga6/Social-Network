namespace SocialNetwork.Business.DTOs.CommentReaction.Responses
{
    public class GetCommentReactionResponse
    {
        public int ReactionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public UserResponse User { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }

    public class UserResponse
    {
        public string Id { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
    }
}

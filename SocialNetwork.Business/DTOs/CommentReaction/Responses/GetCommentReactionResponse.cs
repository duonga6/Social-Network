namespace SocialNetwork.Business.DTOs.CommentReaction.Responses
{
    public class GetCommentReactionResponse
    {
        public int ReactionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}

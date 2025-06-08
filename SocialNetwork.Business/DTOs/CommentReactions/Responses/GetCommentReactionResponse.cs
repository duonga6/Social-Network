namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetCommentReactionResponse
    {
        public Guid Id { set; get; }
        public Guid CommentId { set; get; }
        public int ReactionId { set; get; }
        public string UserId { set; get; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}

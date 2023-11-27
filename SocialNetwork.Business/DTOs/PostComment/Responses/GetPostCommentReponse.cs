namespace SocialNetwork.Business.DTOs.PostComment.Responses
{
    public class GetPostCommentReponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid PostId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}

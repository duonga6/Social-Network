using SocialNetwork.Business.DTOs.User.Responses;

namespace SocialNetwork.Business.DTOs.PostComment.Responses
{
    public class GetPostCommentResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid PostId { get; set; }
        public BasicUserResponse User { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}

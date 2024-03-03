using SocialNetwork.Business.DTOs.Users.Responses;

namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetPostCommentResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid PostId { get; set; }
        public string UserId { set; get; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public Guid? ParentCommentId { set; get; }
    }
}

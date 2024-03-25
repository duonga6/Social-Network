using SocialNetwork.Business.DTOs.Users.Responses;

namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetPostCommentResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string[] Path { set; get; } = null!;
        public Guid PostId { get; set; }
        public BasicUserResponse User { set; get; } = null!;
        public DateTime CreatedAt { get; set; }
        public Guid? ParentCommentId { set; get; }
    }
}

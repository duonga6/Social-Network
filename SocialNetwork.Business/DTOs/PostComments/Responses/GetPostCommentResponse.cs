using SocialNetwork.Business.DTOs.Users.Responses;

namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetPostCommentResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid PostId { get; set; }
        public BasicUserResponse User { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public List<GetPostCommentResponse> ChildrenComment { set; get; } = null!;
    }
}

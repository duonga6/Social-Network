using SocialNetwork.Business.DTOs.PostImage.Responses;

namespace SocialNetwork.Business.DTOs.Post.Responses
{
    public class GetPostResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public List<GetPostImageResponse>? Images { set; get; }
    }
}

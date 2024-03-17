using SocialNetwork.Business.DTOs.PostMedia.Responses;
using SocialNetwork.Business.DTOs.Users.Responses;

namespace SocialNetwork.Business.DTOs.Post.Responses
{
    public class GetPostResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string AuthorId { set; get; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public BasicUserResponse User { set; get; } = null!;
        public List<GetPostMediaResponse>? PostMedias { set; get; }
    }
}

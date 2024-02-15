using SocialNetwork.Business.DTOs.PostMedia.Responses;
using SocialNetwork.Business.DTOs.Users.Responses;

namespace SocialNetwork.Business.DTOs.Post.Responses
{
    public class GetPostResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public BasicUserResponse Author { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public List<GetPostMediaResponse>? PostMedias { set; get; }
    }
}

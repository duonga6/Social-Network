using SocialNetwork.Business.DTOs.PostImage.Requests;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Post.Requests
{
    public class CreatePostRequest
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public ICollection<CreatePostImageRequest> Images { get; set; } = new List<CreatePostImageRequest>();
    }
}

using SocialNetwork.Business.DTOs.PostImage.Requests;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Post.Requests
{
    public class UpdatePostRequest
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public string AuthorId { get; set; } = string.Empty;

        public List<Guid> ImagesDelete { get; set; } = new();
        public List<CreatePostImageRequest> ImagesAdd { get; set; } = new();
        public List<UpdatePostImageRequest> ImagesUpdate { get; set; } = new();

    }
}

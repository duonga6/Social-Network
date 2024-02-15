using SocialNetwork.Business.DTOs.PostMedia.Requests;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SocialNetwork.Business.DTOs.Post.Requests
{
    public class UpdatePostRequest
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        [JsonIgnore]
        public string AuthorId { get; set; } = string.Empty;

        public List<Guid> ImagesDelete { get; set; } = new();
        public List<CreatePostMediaRequest> ImagesAdd { get; set; } = new();
        public List<UpdatePostMediaRequest> ImagesUpdate { get; set; } = new();

    }
}

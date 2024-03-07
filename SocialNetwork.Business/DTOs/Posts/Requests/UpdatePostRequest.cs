using SocialNetwork.Business.DTOs.PostMedia.Requests;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SocialNetwork.Business.DTOs.Post.Requests
{
    public class UpdatePostRequest
    {
        [Required]
        public string Content { get; set; } = string.Empty;
        [JsonIgnore]
        public string AuthorId { get; set; } = string.Empty;

        public List<Guid> MediasDelete { get; set; } = new();
        public List<CreatePostMediaRequest> MediasAdd { get; set; } = new();
        public List<UpdatePostMediaRequest> MediasUpdate { get; set; } = new();

    }
}

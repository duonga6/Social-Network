using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SocialNetwork.Business.DTOs.Post.Requests
{
    public class CreateCommentRequest
    {
        [Required]
        public string Content { get; set; } = string.Empty;
        [JsonIgnore]
        public Guid PostId { get; set; }
        [JsonIgnore]
        public string UserId { get; set; } = string.Empty;
    }
}

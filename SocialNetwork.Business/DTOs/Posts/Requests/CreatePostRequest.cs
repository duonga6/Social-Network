using SocialNetwork.Business.DTOs.PostMedia.Requests;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SocialNetwork.Business.DTOs.Post.Requests
{
    public class CreatePostRequest
    {
        public string Content { get; set; } = string.Empty;
        public ICollection<CreatePostMediaRequest> PostMedias { get; set; } = new List<CreatePostMediaRequest>();
    }
}

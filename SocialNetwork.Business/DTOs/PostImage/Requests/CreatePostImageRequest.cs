using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.PostImage.Requests
{
    public class CreatePostImageRequest
    {
        [Required]
        [MaxLength(100)]
        public string Url { get; set; } = string.Empty;
    }
}

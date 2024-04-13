using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreatePostMediaRequest
    {
        public string? Title { set; get; }
        [Required]
        public int MediaTypeId { set; get; }
        [Required]
        public string Url { get; set; } = string.Empty;
    }
}

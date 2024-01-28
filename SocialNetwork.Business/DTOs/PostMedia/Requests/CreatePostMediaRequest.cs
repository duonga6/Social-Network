using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.PostMedia.Requests
{
    public class CreatePostMediaRequest
    {
        public string Title { set; get; } = string.Empty;
        [Required]
        public int MediaTypeId { set; get; }
        [Required]
        public string Url { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreateSharePostRequest
    {
        public string? Content { set; get; }
        [Required]
        public Guid SharePostId { set; get; }
    }
}

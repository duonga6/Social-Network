using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class UpdatePostCommentRequest
    {
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public Guid PostId { get; set; }
    }
}

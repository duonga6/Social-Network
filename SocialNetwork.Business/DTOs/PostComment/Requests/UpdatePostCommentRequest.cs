using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.PostComment.Requests
{
    public class UpdatePostCommentRequest
    {
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public Guid PostId { get; set; }
    }
}

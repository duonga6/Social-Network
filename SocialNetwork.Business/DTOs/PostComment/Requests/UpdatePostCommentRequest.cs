using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.PostComment.Requests
{
    public class UpdatePostCommentRequest
    {
        [Required]
        public string Content {  get; set; } = string.Empty;
    }
}

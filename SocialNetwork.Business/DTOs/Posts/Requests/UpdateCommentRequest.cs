using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Post.Requests
{
    public class UpdateCommentRequest
    {
        [Required]
        public string Content {  get; set; } = string.Empty;
    }
}

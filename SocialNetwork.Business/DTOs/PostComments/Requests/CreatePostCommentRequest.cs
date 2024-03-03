using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.PostComment.Requests
{
    public class CreatePostCommentRequest
    {
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public Guid PostId { get; set; }
        public Guid? ParentCommentId { set; get; }
    }
}

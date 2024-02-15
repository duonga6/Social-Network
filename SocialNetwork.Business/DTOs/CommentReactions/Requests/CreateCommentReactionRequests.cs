using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreateCommentReactionRequests
    {
        [Required]
        public Guid CommentId { set; get; }
        [Required]
        public int ReactionId { set; get; }
    }
}

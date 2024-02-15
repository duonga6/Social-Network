using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.CommentReactions.Requests
{
    public class CreateCommentReactionRequest
    {
        [Required]
        public int ReactionId { get; set; }
    }
}

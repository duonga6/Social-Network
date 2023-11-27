using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.CommentReaction.Requests
{
    public class CreateCommentReactionRequest
    {
        [Required]
        public int ReactionId { get; set; }
    }
}

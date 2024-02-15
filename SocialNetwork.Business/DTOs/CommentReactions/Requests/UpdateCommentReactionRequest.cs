using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class UpdateCommentReactionRequest
    {
        [Required]
        public int ReactionId { set; get; }
    }
}

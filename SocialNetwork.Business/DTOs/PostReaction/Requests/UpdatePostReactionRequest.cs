using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.PostReaction.Requests
{
    public class UpdatePostReactionRequest
    {
        [Required]
        public Guid PostId { set; get; }
        [Required]
        public int ReactionId { set; get; }
    }
}

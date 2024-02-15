using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.PostReaction.Requests
{
    public class CreatePostReactionRequest
    {
        [Required]
        public int ReactionId { get; set; }
    }
}

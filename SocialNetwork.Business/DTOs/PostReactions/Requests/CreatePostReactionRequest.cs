using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreatePostReactionRequest
    {
        [Required]
        public int ReactionId { get; set; }
    }
}

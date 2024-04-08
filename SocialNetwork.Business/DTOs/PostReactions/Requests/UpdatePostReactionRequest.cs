using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class UpdatePostReactionRequest
    {
        [Required]
        public int ReactionId { set; get; }
    }
}

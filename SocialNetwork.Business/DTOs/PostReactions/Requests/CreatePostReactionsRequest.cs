using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreatePostReactionsRequest
    {
        [Required]
        public Guid PostId { set; get; }
        [Required]
        public int ReactionId { set; get; }
    }
}

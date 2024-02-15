using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.PostReaction.Requests
{
    public class CreatePostReactionsRequest
    {
        [Required]
        public Guid PostId { set; get; }
        [Required]
        public int ReactionId { set; get; }
    }
}

using SocialNetwork.Business.DTOs.Responses;

namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetPostReactionResponse
    {
        public Guid Id { set; get; }
        public int ReactionId { set; get; }
        public Guid PostId { set; get; }
        public string UserId { set; get; } = string.Empty;
    }
}

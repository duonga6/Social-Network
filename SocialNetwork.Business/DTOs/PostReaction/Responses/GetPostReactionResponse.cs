using SocialNetwork.Business.DTOs.User.Responses;

namespace SocialNetwork.Business.DTOs.PostReaction.Responses
{
    public class GetPostReactionResponse
    {
        public int ReactionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public BasicUserResponse User { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}

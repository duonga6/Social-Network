namespace SocialNetwork.Business.DTOs.PostReaction.Responses
{
    public class GetPostReactionResponse
    {
        public int ReactionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}

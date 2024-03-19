namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetOverviewReactionResponse
    {
        public List<ReactionWithCount> Reactions { set; get; } = null!;
        public UserReacted UserReacted { set; get; } = null!;
    }

    public class ReactionWithCount
    {
        public int ReactionId { set; get; }
        public int Total { set; get; }
    }

    public class UserReacted
    {
        public Guid Id { set; get; }
        public string UserId { set; get; } = string.Empty;
        public int ReactionId { set; get; }
    }
}

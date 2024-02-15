namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetOverviewReactionResponse
    {
        public List<GetReactionResponse> Reactions { set; get; } = null!;
        public int Total { set; get; }
        public GetReactionResponse UserReacted { set; get; } = null!;
    }
}

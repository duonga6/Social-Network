namespace SocialNetwork.Business.DTOs.Responses
{
    public class OverviewReactionResponse<T> where T : class
    {
        public List<int> ReactionTypes { set; get; } = null!;
        public int Total { set; get; }
        public T UserReacted { set; get; } = null!;
    }

}

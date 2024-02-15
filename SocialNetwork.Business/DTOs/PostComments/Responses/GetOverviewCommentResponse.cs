namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetOverviewCommentResponse
    {
        public List<GetPostCommentResponse> Comments { set; get; } = null!;
        public int Total { set; get; } = 0;
    }
}

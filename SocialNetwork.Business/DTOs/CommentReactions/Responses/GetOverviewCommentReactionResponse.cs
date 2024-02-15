using SocialNetwork.Business.DTOs.Responses;

namespace SocialNetwork.Business.DTOs.CommentReactions.Responses
{
    public class GetOverviewCommentReactionResponse
    {
        public List<GetReactionResponse> ReactionTypes { set; get; } = null!;
        public int Total { set; get; }
        public GetCommentReactionResponse UserReacted { set; get; } = null!;
    }
}

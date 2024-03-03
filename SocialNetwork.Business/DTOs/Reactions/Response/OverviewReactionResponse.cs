
using SocialNetwork.Business.DTOs.PostReactions.Responses;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.DTOs.Users.Responses;

namespace SocialNetwork.Business.DTOs.Response
{
    public class OverviewReactionResponse<T> where T : class
    {
        public List<int> ReactionTypes { set; get; } = null!;
        public int Total { set; get; }
        public T UserReacted { set; get; } = null!;
    }

}

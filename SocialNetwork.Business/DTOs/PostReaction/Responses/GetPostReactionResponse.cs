using SocialNetwork.Business.DTOs.Reaction.Response;
using SocialNetwork.Business.DTOs.User.Responses;

namespace SocialNetwork.Business.DTOs.PostReaction.Responses
{
    public class GetPostReactionResponse
    {
        public int Id { set; get; }
        public string Name { set; get; } = string.Empty;
        public string IconUrl { set; get; } = string.Empty;
        public List<string> Users { set; get; } = null!;
        public int Total { set; get; }
    }
}

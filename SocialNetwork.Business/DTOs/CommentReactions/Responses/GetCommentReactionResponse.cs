using SocialNetwork.Business.DTOs.Users.Responses;

namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetCommentReactionResponse
    {
        public Guid Id { set; get; }
        public GetReactionResponse Reaction { set; get; } = null!;
        public BasicUserResponse User { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}

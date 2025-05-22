using SocialNetwork.DataAccess.Enums;

namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetFriendshipResponse
    {
        public Guid Id { set; get; }
        public BasicUserResponse RequestUser { set; get; } = null!;
        public BasicUserResponse TargetUser { set; get; } = null!;
        public DateTime UpdatedAt { set; get; }
        public FriendshipEnum FriendStatus { set; get; }
    }
}

using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.Business.DTOs.Friendship.Responses
{
    public class GetFriendshipResponse
    {
        public Guid Id { set; get; }
        public string RequestUserId { set; get; } = string.Empty;
        public string TargetUserId { set; get; } = string.Empty;
        public string CreatedAt { set; get; } = string.Empty;
        public string UpdatedAt { set; get; } = string.Empty;
        public FriendshipStatus FriendStatus { set; get; }
    }
}

using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.Business.DTOs.Friendship.Responses
{
    public class GetFriendshipResponse
    {
        public Guid Id { set; get; }
        public UserRespone RequestUser { set; get; } = null!;
        public UserRespone TargetUser { set; get; } = null!;
        public string UpdatedAt { set; get; } = string.Empty;
        public FriendshipEnum FriendStatus { set; get; }
    }

    public class UserRespone
    {
        public string Id { set; get; } = string.Empty;
        public string FullName { set; get; } = string.Empty;
        public string AvatarUrl { set; get; } = string.Empty;
    }
}

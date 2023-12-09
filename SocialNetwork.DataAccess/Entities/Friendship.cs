using SocialNetwork.DataAccess.Entities.Base;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.DataAccess.Entities
{
    public class Friendship : BaseEntity
    {
        public string RequestUserId { get; set; }
        public string TargetUserId { get; set; }
        public FriendshipStatus FriendStatus { set; get; }

        public User RequestUser { get; set; }
        public User TargetUser { get; set; }
    }
}

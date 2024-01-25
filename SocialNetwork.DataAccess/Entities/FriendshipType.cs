using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class FriendshipType : BaseEntity<int>
    {
        public string Name { set; get; }
    }
}

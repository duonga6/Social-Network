using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class GroupRequestJoin : BaseEntity<Guid>
    {
        public Guid GroupId { set; get; }
        public string UserId { set; get; }
    }
}

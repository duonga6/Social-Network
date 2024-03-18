using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class Group : BaseEntity<Guid>
    {
        public string Name { set; get; }
        public string Description { set; get; }

        public virtual ICollection<Post> Posts { set; get; }
        public virtual ICollection<GroupMember> GroupMembers { set; get; }
    }
}

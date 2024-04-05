using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class GroupInvite : BaseEntity<Guid>
    {
        public Guid GroupId { set; get; }
        public string UserId { set; get; }
        public bool Accepted { set; get; }

        public virtual Group Group { set; get; }
        public virtual User User { get; set; }
    }
}

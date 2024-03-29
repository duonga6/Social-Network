using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class GroupAdministrator : BaseEntity<Guid>
    {
        public string UserId { set; get; }
        public Guid GroupId { set; get; }
        public bool IsSuperAdmin { set; get; }

        public virtual User User { set; get; }
        public virtual Group Group { set; get; }
    }
}

using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class GroupInvite : BaseEntity<Guid>
    {
        public Guid GroupId { set; get; }
        public string UserId { set; get; }
        public bool AdminAccepted { set; get; }
        public bool UserAccepted { set; get; }
        public string CreatedId { set; get; }

        public Group Group { set; get; }
        public User User { get; set; }
        public User CreatedBy { set; get; }
    }
}

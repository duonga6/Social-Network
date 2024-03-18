using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class SharePost : BaseEntity<Guid>
    {
        public Guid PostId { set; get; }
        public string UserId { set; get; }
        public string Content { set; get; }
        public string Privacy { set; get; }

        public virtual Post Post { set; get; }
        public virtual User User { set; get; }
    }
}

using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class NotificationDetails : BaseEntity<Guid>
    {
        public Guid NotificationId { set; get; }
        public string Content { set; get; }
        public string Url { set; get; }
        public string AuthorId { set; get; }

        public virtual Notification Notification {set;get;}
        public virtual User Author { set; get; }
    }
}

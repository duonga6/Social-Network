using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class Notification : BaseEntity<Guid>
    {
        public string UserId { get; set; }
        public DateTime? ReadAt { set; get; }
        public string NotifiableType { set; get; }
        public Guid NotifiableId { set; get; }

        public virtual User User { get; set; }
        public virtual NotificationDetails NotificationDetail { set; get; }
    }
}

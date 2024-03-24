using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class Notification : BaseEntity<Guid>
    {
        public string FromId { get; set; }
        public string ToId { set; get; }
        public DateTime? ReadAt { set; get; }
        public string NotifiableId { set;get; }
        public string NotificationType { set; get; }
        public string Content { set; get; }
        public string JsonDetail { set; get; }
        public virtual User FromUser { get; set; }
        public virtual User ToUser { get; set; }
    }
}

using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class NotificationService : BaseEntity
    {
        public string Content { get; set; }
        public string UserId { get; set; }
        public bool Seen { get; set; }

        public virtual User User { get; set; }
    }
}

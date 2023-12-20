using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class Notification : BaseEntity
    {
        public string Content { get; set; }
        public string TargetUserId { get; set; }
        public string FromUserId { get; set; }
        public bool Seen { get; set; }

        public virtual User TargetUser { get; set; }
        public virtual User FromUser { get; set; }
    }
}

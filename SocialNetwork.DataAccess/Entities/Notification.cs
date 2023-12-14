using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class Notification : BaseEntity
    {
        public string Content { get; set; }
        public string UserId { get; set; }
        public string Url { get; set; }
        public bool Seen { get; set; }

        public virtual User User { get; set; }
    }
}

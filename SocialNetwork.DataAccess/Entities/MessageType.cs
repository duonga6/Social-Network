using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class MessageType : BaseEntity<int>
    {
        public string Name { set; get; }

        public virtual ICollection<Message> Messages { set; get; }
    }
}

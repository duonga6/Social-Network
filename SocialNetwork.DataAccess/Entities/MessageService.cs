using SocialNetwork.DataAccess.Entities.Base;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.DataAccess.Entities
{
    public class MessageService : BaseEntity
    {
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public MessageType MessageType { get; set; }
        public string Content { get; set; }

        public virtual User Sender { set;get; }
        public virtual User Receiver { set; get; }
    }
}

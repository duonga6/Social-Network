using SocialNetwork.DataAccess.Entities.Base;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.DataAccess.Entities
{
    public class Message : BaseEntity<Guid>
    {
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public int MediaTypeId { get; set; }
        public string Content { get; set; }
        public bool IsRevoked { set; get; }

        public virtual User Sender { set;get; }
        public virtual User Receiver { set; get; }
        public virtual MediaType MediaType{ set; get; }
    }
}

using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.DataAccess.Entities
{
    public class Conversation : BaseEntity<Guid>
    {
        public string Name { set; get; }
        public string Image { set; get; }
        public ConversationType Type { set; get; }
        public string CreatedId { set; get; }


        public User CreatedBy { set; get; }
        public List<ConversationParticipant> ConversationParticipants { set; get; }
        public List<Message> Messages { set; get; }
        public List<MessageMemberReaded> MessageReadeds { set; get; }

    }
}

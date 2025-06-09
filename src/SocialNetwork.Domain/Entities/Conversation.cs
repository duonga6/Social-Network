namespace SocialNetwork.Domain.Entities;

public class Conversation : EntityAuditBase<Guid>
{
    public string Name { set; get; }
    public string Image { set; get; }
    public ConversationType Type { set; get; }

    public User CreatedUser { set; get; }
    public List<ConversationParticipant> ConversationParticipants { set; get; }
    public List<Message> Messages { set; get; }
    public List<MessageMemberReaded> MessageReadeds { set; get; }

}

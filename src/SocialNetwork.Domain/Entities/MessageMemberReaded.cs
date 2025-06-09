namespace SocialNetwork.Domain.Entities;

public class MessageMemberReaded : EntityAuditBase<Guid>
{
    public Guid MessageId { set; get; }
    public string UserId { set; get; }
    public Guid ConversationId { set; get; }

    public Message Message { set; get; }
    public User User { set; get; }
    public Conversation Conversation { set; get; }
}

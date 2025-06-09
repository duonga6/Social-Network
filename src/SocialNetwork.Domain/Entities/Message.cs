namespace SocialNetwork.Domain.Entities;

public class Message : EntityAuditBase<Guid>
{
    public string UserId { set; get; }
    public string Content { set; get; }
    public DateTime? ReadedAt { set; get; }
    public Guid ConversationId { set; get; }
    public DateTime? RevokedAt { set; get; }
    public Guid? ReplyId { set; get; }
    public MessageType MessageType { set; get; }
    public Guid ParticipantId { set; get; }

    public User User { set; get; }
    public Conversation Conversation { set; get; }
    public Message ReplyMessage { set; get; }
    public ConversationParticipant Participant { set; get; }

    public List<MessageMemberReaded> MessageReadeds { set; get; }
}

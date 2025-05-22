namespace SocialNetwork.DataAccess.Entities
{
    public class ConversationParticipant : EntityAuditBase<Guid>
    {
        public string UserId { set; get; }
        public Guid ConversationId { set; get; }
        public string UserContactName { set; get; }
        public bool IsAdmin { set; get; }
        public bool IsSuperAdmin { set; get; }

        public Conversation Conversation { set; get; }
        public User User { set; get; }
    }
}

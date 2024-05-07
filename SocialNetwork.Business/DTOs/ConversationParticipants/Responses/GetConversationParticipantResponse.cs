namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetConversationParticipantResponse
    {
        public Guid Id { set; get; }
        public Guid ConversationId { set; get; }
        public string UserContactName { set; get; } = string.Empty;
        public BasicUserResponse User { set; get; } = null!;
    }
}

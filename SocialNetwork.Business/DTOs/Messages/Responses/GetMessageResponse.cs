using SocialNetwork.DataAccess.Enums;

namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetMessageResponse
    {
        public Guid Id { get; set; }
        public BasicUserResponse User { get; set; } = null!;
        public string Content { get; set; } = string.Empty;
        public MessageEnum MessageType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ReadedAt { set; get; }
        public Guid ConversationId { set; get; }
        public GetConversationParticipantResponse Participant { set; get; } = null!;
        public GetMessageResponse? ReplyMessage { set; get; } = null!;
    }
}

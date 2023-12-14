using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.Business.DTOs.Message.Responses
{
    public class GetMessageResponse
    {
        public Guid Id { get; set; }
        public string SenderId { get; set; } = string.Empty;
        public string ReceiverId { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public MessageType MessageType { get; set; }
    }
}

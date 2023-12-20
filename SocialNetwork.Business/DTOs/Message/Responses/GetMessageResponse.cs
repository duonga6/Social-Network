using SocialNetwork.Business.DTOs.User.Responses;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.Business.DTOs.Message.Responses
{
    public class GetMessageResponse
    {
        public Guid Id { get; set; }
        public BasicUserResponse Sender { get; set; } = null!;
        public BasicUserResponse Receiver { get; set; } = null!;
        public string Content { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public MessageType MessageType { get; set; }
    }
}

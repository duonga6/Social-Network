using SocialNetwork.DataAccess.Enums;

namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetConversationResponse
    {
        public Guid Id { set; get; }
        public string Name { set; get; } = string.Empty;
        public ConversationType Type { set; get; }
        public List<string> Images { set; get; } = null!;
        public DateTime UpdatedAt { set; get; }
        public GetMessageResponse LastMessage { set; get; } = null!;
    }
}

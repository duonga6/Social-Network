namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreateConversationRequest
    {
        public string? Name { set; get; } = string.Empty;
        public List<string> UserIds { set; get; } = null!;
    }
}

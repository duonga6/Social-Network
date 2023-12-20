namespace SocialNetwork.Business.DTOs.User.Responses
{
    public class BasicUserResponse
    {
        public string Id { get; set; } = string.Empty;
        public string FullName { set; get; } = string.Empty;
        public string AvatarUrl { set; get; } = string.Empty;
    }
}

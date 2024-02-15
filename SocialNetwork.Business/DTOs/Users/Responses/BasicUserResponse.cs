namespace SocialNetwork.Business.DTOs.Users.Responses
{
    public class BasicUserResponse
    {
        public string Id { get; set; } = string.Empty;
        public string FullName { set; get; } = string.Empty;
        public string AvatarUrl { set; get; } = string.Empty;
    }
}

namespace SocialNetwork.Business.DTOs.Users.Responses
{
    public class BasicUserResponse
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { set; get; } = string.Empty;
        public string LastName { set; get; } = string.Empty;
        public string AvatarUrl { set; get; } = string.Empty;
    }
}

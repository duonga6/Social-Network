namespace SocialNetwork.Business.DTOs.Responses
{
    public class GetUserByAdminResponse
    {
        public string Id { set; get; } = string.Empty;
        public string FirstName { set; get; } = string.Empty;
        public string LastName { set; get; } = string.Empty;
        public string AvatarUrl { set; get; } = string.Empty;
        public string Email { set; get; } = string.Empty;
        public string Address { set; get; } = string.Empty;
        public int Gender { set; get; }
        public int TotalPost { set; get; }
        public int TotalFriend { set; get; }
        public string[] Roles { set; get; } = null!;
    }
}

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreateUserRoleRequest
    {
        public string[] Roles { set; get; } = null!;
    }
}

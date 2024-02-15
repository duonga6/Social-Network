using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Users.Requests
{
    public  class AddRolesToUserRequest
    {
        [Required]
        public List<string> Roles { get; set; } = null!;
    }
}

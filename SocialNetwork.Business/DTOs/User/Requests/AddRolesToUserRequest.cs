using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.User.Requests
{
    public  class AddRolesToUserRequest
    {
        [Required]
        public List<string> Roles { get; set; } = null!;
    }
}

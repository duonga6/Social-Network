using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.User.Requests
{
    public  class AddRolesToUserRequest
    {
        [Required]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public List<string> Roles { get; set; } = null!;
    }
}

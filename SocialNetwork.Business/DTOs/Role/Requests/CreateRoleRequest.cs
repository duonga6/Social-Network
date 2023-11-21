using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Role.Request
{
    public class CreateRoleRequest
    {
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}

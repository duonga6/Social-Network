using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Role.Request
{
    public class UpdateRoleRequest
    {
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}

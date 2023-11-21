using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Role.Request
{
    public class UpdateRoleRequest
    {
        [Required]
        public string Id { get; set; } = string.Empty;
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class UpdateRoleRequest
    {
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}

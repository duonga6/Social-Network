using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreateRoleRequest
    {
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}

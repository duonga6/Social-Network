using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Role.Request
{
    public class DeleteRoleRequest
    {
        [Required]
        public string Id { set; get; } = string.Empty;
    }
}

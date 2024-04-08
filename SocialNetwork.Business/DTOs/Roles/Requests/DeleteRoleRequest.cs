using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class DeleteRoleRequest
    {
        [Required]
        public string Id { set; get; } = string.Empty;
    }
}

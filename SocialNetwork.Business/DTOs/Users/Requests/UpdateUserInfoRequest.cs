using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class UpdateUserInfoRequest
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Gender { set; get; }
    }
}

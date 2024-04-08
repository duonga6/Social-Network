using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreateGroupMemberRequest
    {
        [Required]
        public Guid GroupId { set; get; }
    }
}

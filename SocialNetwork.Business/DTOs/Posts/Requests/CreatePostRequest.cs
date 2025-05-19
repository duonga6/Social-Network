using SocialNetwork.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreatePostRequest
    {
        public string? Content { get; set; }
        public ICollection<CreatePostMediaRequest>? PostMedias { get; set; } = new List<CreatePostMediaRequest>();
        public Guid? GroupId { set; get; }
        [Required]
        public PostAccess Access { set; get; }
        public Guid? SharePostId { set; get; }
    }
}

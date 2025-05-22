using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.DataAccess.Enums;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class UpdatePostRequest
    {
        public string? Content { get; set; }
        public List<Guid>? MediasDelete { get; set; } = new();
        public PostAccess Access { set; get; }
        public List<CreatePostMediaRequest>? MediasAdd { get; set; } = new();
        public List<UpdatePostMediaRequest>? MediasUpdate { get; set; } = new();

    }
}

using SocialNetwork.Business.Utilities.Enum;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class UpdateSharePostRequest
    {
        public string? Content { set; get; }
        public PostAccess Access { set;get; }
    }
}

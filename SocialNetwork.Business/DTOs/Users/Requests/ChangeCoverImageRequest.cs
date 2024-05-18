using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class ChangeCoverImageRequest
    {
        [Required]
        public string Url { set; get; } = string.Empty;
    }
}

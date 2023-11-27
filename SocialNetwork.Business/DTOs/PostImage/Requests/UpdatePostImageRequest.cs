using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.DTOs.PostImage.Requests
{
    public class UpdatePostImageRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Url { get; set; } = string.Empty;
    }
}

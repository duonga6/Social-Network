﻿using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class UpdatePostMediaRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { set; get; } = string.Empty;
        [Required]
        public int MediaTypeId { set; get; }
        [Required]
        public string Url { get; set; } = string.Empty;
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.DTOs.Requests
{
    public class CreateGroupInviteRequest
    {
        [Required]
        public Guid GroupId { set; get; }
    }
}

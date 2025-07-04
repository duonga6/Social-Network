﻿namespace SocialNetwork.Business.DTOs.Responses
{
    public class UserWithTokenResponse
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { set; get; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public string AvatarUrl { set; get; } = string.Empty;
        public int Gender { set; get; }

        public Token Token { set; get; } = null!;
    }
}

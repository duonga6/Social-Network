using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Gender { set; get; }
        public string AvatarUrl { get; set; }
        public string CoverImageUrl { set; get; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime DateOfBirth { get; set; }
        public int Status { set; get; } = 1;

        public string GetFullName() => $"{FirstName} {LastName}";

        [NotMapped]
        public string Password { set; get; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual ICollection<PostReaction> PostReactions { get; set; }
        public virtual ICollection<CommentReaction> CommentReactions { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<Friendship> Friendships1 { get; set; }
        public virtual ICollection<Friendship> Friendships2 { get; set; }
        public virtual ICollection<Message> MessagesSent { set; get; }
        public virtual ICollection<Message> MessageReceived { set; get; }
        public virtual ICollection<Notification> NotificationsSend { set; get; }
        public virtual ICollection<Notification> NotificationsReceive { set; get; }
        public virtual Gender Gender_FK { set; get; }
    }
}

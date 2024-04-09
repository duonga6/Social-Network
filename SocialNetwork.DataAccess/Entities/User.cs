using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
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

        [JsonIgnore]
        public virtual ICollection<Post> Posts { get; set; }
        [JsonIgnore]
        public virtual ICollection<PostComment> PostComments { get; set; }
        [JsonIgnore]
        public virtual ICollection<PostReaction> PostReactions { get; set; }
        [JsonIgnore]
        public virtual ICollection<CommentReaction> CommentReactions { get; set; }
        [JsonIgnore]
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        [JsonIgnore]
        public virtual ICollection<Friendship> Friendships1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Friendship> Friendships2 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Message> MessagesSent { set; get; }
        [JsonIgnore]
        public virtual ICollection<Message> MessageReceived { set; get; }
        [JsonIgnore]
        public virtual ICollection<Notification> NotificationsReceive { set; get; }
        [JsonIgnore]
        public virtual ICollection<Notification> NotificationSend { set; get; }
        [JsonIgnore]
        public virtual Gender Gender_FK { set; get; }
        [JsonIgnore]
        public virtual ICollection<GroupMember> GroupMembers{ set; get; }
        [JsonIgnore]
        public virtual ICollection<PostMedia> PostMedias { set; get; }
        [JsonIgnore]
        public virtual ICollection<Group> GroupOwner { set; get; }
        [JsonIgnore]
        public virtual ICollection<GroupAdministrator> GroupAdministrators { set; get; }
        [JsonIgnore]
        public virtual ICollection<GroupInvite> GroupInvites { set; get; }
    }
}

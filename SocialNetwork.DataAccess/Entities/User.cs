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
        public ICollection<Post> Posts { get; set; }
        [JsonIgnore]
        public ICollection<PostComment> PostComments { get; set; }
        [JsonIgnore]
        public ICollection<PostReaction> PostReactions { get; set; }
        [JsonIgnore]
        public ICollection<CommentReaction> CommentReactions { get; set; }
        [JsonIgnore]
        public ICollection<RefreshToken> RefreshTokens { get; set; }
        [JsonIgnore]
        public ICollection<Friendship> Friendships1 { get; set; }
        [JsonIgnore]
        public ICollection<Friendship> Friendships2 { get; set; }
        [JsonIgnore]
        public ICollection<Message> Messages { set; get; }
        [JsonIgnore]
        public ICollection<Notification> NotificationsReceive { set; get; }
        [JsonIgnore]
        public ICollection<Notification> NotificationSend { set; get; }
        [JsonIgnore]
        public Gender Gender_FK { set; get; }
        [JsonIgnore]
        public ICollection<GroupMember> GroupMembers{ set; get; }
        [JsonIgnore]
        public ICollection<PostMedia> PostMedias { set; get; }
        [JsonIgnore]
        public ICollection<Group> GroupOwner { set; get; }
        [JsonIgnore]
        public ICollection<GroupInvite> GroupInvites { set; get; }
        [JsonIgnore]
        public ICollection<GroupInvite> GroupInvitesCreate { set; get; }
        [JsonIgnore]
        public ICollection<Conversation> ConversationCreated { set; get; }
        [JsonIgnore]
        public ICollection<ConversationParticipant> ConversationParticipants { set; get; }
        [JsonIgnore]
        public ICollection<MessageMemberReaded> MessageReadeds { set; get; }
        [JsonIgnore]
        public ICollection<StrangeMessageBlock> StrangeMessageBlocked { set; get; }
        [JsonIgnore]
        public ICollection<StrangeMessageBlock> StrangeMessageIsBlocked { set; get; }

    }
}   

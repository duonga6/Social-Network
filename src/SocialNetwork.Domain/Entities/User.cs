namespace SocialNetwork.Domain.Entities;

public class User : EntityAuditBase<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Address { get; set; }
    public Gender Gender { get; set; }
    public string AvatarUrl { get; set; }
    public string CoverImageUrl { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string ConfirmEmailCode { get; set; }
    public bool IsConfirmedEmail { get; set; }
    public DateTimeOffset ConfirmCodeCreateDate { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public DateTimeOffset LastChangeNameDate { get; set; }

    public ICollection<Post> Posts { get; set; }
    public ICollection<PostComment> PostComments { get; set; }
    public ICollection<PostReaction> PostReactions { get; set; }
    public ICollection<CommentReaction> CommentReactions { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }
    public ICollection<Friendship> Friendships1 { get; set; }
    public ICollection<Friendship> Friendships2 { get; set; }
    public ICollection<Message> Messages { set; get; }
    public ICollection<Notification> NotificationsReceive { set; get; }
    public ICollection<Notification> NotificationSend { set; get; }
    public ICollection<GroupMember> GroupMembers { set; get; }
    public ICollection<PostMedia> PostMedias { set; get; }
    public ICollection<Group> GroupOwner { set; get; }
    public ICollection<GroupInvite> GroupInvites { set; get; }
    public ICollection<GroupInvite> GroupInvitesCreate { set; get; }
    public ICollection<Conversation> ConversationCreated { set; get; }
    public ICollection<ConversationParticipant> ConversationParticipants { set; get; }
    public ICollection<MessageMemberReaded> MessageReadeds { set; get; }
    public ICollection<StrangeMessageBlock> StrangeMessageBlocked { set; get; }
    public ICollection<StrangeMessageBlock> StrangeMessageIsBlocked { set; get; }
    public ICollection<ReportViolation> ReportsSend { set; get; }
    public ICollection<ReportViolation> ReportsSolved { set; get; }
    public ICollection<ActionReportDid> ActionReportsDids { set; get; }
    public ICollection<UserRole> UserRoles { get; set; }
}
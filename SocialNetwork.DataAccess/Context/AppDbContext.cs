using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.DataAccess.Entities;
using System.Reflection;

namespace SocialNetwork.DataAccess.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName != null && tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName[6..]);
                }
            }
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostReaction> PostReactions { get; set; }
        public DbSet<CommentReaction> CommentReactions { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<PostMedia> PostMedias { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Gender> Genders { set; get; }
        public DbSet<FriendshipType> FriendshipTypes { set; get; }
        public DbSet<MediaType> MediaTypes { set; get; }
        public DbSet<Group> Groups { set; get; }
        public DbSet<GroupMember> GroupMembers { set; get; }
        public DbSet<GroupInvite> GroupInvites { set; get; }
        public DbSet<Conversation> Conversations { set; get; }
        public DbSet<ConversationParticipant> ConversationParticipants { set; get; }
        public DbSet<StrangeMessageBlock> StrangeMessageBlocks { set; get; }
        public DbSet<MessageMemberReaded> MessageMemberReadeds { set; get; }
        public DbSet<ReportViolation> ReportViolations { set; get; }
        public DbSet<ActionReport> ActionReports { set; get; }
        public DbSet<ActionReportDid> ActionReportDids { set; get; }
    }
}

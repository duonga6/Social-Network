using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Abstractions.Entities;
using SocialNetwork.Domain.Entities;
using System.Reflection;

namespace SocialNetwork.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            var baseEntityType = typeof(EntityBase<>);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;
                var baseType = clrType.BaseType;
                while (baseType != null)
                {
                    if (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == baseEntityType)
                    {
                        builder.Entity(clrType).HasKey("Id");
                        break;
                    }
                    baseType = baseType?.BaseType;
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
        public DbSet<Group> Groups { set; get; }
        public DbSet<GroupMember> GroupMembers { set; get; }
        public DbSet<GroupInvite> GroupInvites { set; get; }
        public DbSet<Conversation> Conversations { set; get; }
        public DbSet<ConversationParticipant> ConversationParticipants { set; get; }
        public DbSet<StrangeMessageBlock> StrangeMessageBlocks { set; get; }
        public DbSet<MessageMemberReaded> MessageMemberReadeds { set; get; }
        public DbSet<ReportViolation> ReportViolations { set; get; }
        public DbSet<ReportAction> ActionReports { set; get; }
        public DbSet<ActionReportDid> ActionReportDids { set; get; }
        public DbSet<IPLimit> IPLimits { set; get; }
    }
}

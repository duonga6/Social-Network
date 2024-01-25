using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class CommentReactionConfigurations : IEntityTypeConfiguration<CommentReaction>
    {
        public void Configure(EntityTypeBuilder<CommentReaction> builder)
        {
            builder.HasOne(p => p.Reaction)
               .WithMany(r => r.CommentReactions)
               .HasForeignKey(p => p.ReactionId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.User)
                .WithMany(u => u.CommentReactions)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Comment)
                .WithMany(p => p.Reactions)
                .HasForeignKey(p => p.CommentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => new
            {
                p.UserId,
                p.CommentId
            }).IsUnique();
        }
    }
}

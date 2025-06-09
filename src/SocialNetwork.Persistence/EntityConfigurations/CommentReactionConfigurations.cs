using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Persistence.EntityConfigurations
{
    public class CommentReactionConfigurations : IEntityTypeConfiguration<CommentReaction>
    {
        public void Configure(EntityTypeBuilder<CommentReaction> builder)
        {
            builder.HasOne(p => p.Reaction)
               .WithMany(r => r.CommentReactions)
               .HasForeignKey(p => p.ReactionId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.CreatedUser)
                .WithMany(u => u.CommentReactions)
                .HasForeignKey(p => p.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Comment)
                .WithMany(p => p.Reactions)
                .HasForeignKey(p => p.CommentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => new
            {
                p.CreatedBy,
                p.CommentId
            }).IsUnique();
        }
    }
}

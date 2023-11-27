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
               .HasConstraintName("FK_CommentReaction_Reaction")
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.User)
                .WithMany(u => u.CommentReactions)
                .HasForeignKey(p => p.UserId)
                .HasConstraintName("FK_CommentReaction_User")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Comment)
                .WithMany(p => p.Reactions)
                .HasForeignKey(p => p.CommentId)
                .HasConstraintName("FK_CommentReaction_Post")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasKey(p => new
            {
                p.ReactionId,
                p.UserId,
                p.CommentId
            });

            builder.ToTable("CommentReactions");
        }
    }
}

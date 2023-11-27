using SocialNetwork.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class PostReactionConfigurations : IEntityTypeConfiguration<PostReaction>
    {
        public void Configure(EntityTypeBuilder<PostReaction> builder)
        {
            builder.HasOne(p => p.Reaction)
                .WithMany(r => r.PostReactions)
                .HasForeignKey(p => p.ReactionId)
                .HasConstraintName("FK_PostReaction_Reaction")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.User)
                .WithMany(u => u.PostReactions)
                .HasForeignKey(p => p.UserId)
                .HasConstraintName("FK_PostReaction_User")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Post)
                .WithMany(p => p.Reactions)
                .HasForeignKey(p => p.PostId)
                .HasConstraintName("FK_PostReaction_Post")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasKey(p => new
            {
                p.PostId,
                p.UserId
            });

            builder.ToTable("PostReactions");
        }
    }
}

using SocialNetwork.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class PostCommentConfigurations : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            builder.Property(p => p.Content).IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(u => u.PostComments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.ParentComment)
                .WithMany(x => x.ChildrenComment)
                .HasForeignKey(x => x.ParentCommentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasKey(x => x.Id);

        }
    }
}

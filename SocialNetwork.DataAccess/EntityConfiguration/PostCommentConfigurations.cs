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
                .HasConstraintName("FK_PostComment_User")
                .IsRequired();

            builder.ToTable("PostComment");
        }
    }
}

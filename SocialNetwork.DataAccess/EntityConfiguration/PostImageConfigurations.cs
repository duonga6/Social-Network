using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    internal class PostImageConfigurations : IEntityTypeConfiguration<PostImage>
    {
        public void Configure(EntityTypeBuilder<PostImage> builder)
        {
            builder.HasOne(i => i.Post)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.PostId)
                .HasConstraintName("FK_PostImage_Image")
                .IsRequired();

            builder.Property(i => i.Url)
                .IsRequired()
                .HasMaxLength(100);

            builder.ToTable("PostImages");
        }
    }
}

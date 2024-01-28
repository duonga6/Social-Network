using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    internal class PostMediaConfigurations : IEntityTypeConfiguration<PostMedia>
    {
        public void Configure(EntityTypeBuilder<PostMedia> builder)
        {
            builder.HasOne(i => i.Post)
                .WithMany(p => p.PostMedias)
                .HasForeignKey(i => i.PostId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.MediaType)
                .WithMany(x => x.PostMedias)
                .HasForeignKey(x => x.MediaTypeId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(i => i.Url)
                .IsRequired();

            builder.Property(i => i.Title)
                .HasMaxLength(200)
                .IsRequired(false);
        }
    }
}

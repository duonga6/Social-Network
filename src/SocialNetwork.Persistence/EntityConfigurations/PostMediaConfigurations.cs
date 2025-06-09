using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Persistence.EntityConfigurations
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

            builder.Property(i => i.Url)
                .IsRequired();

            builder.Property(i => i.Title)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.HasOne(x => x.User)
               .WithMany(x => x.PostMedias)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired(true);
        }
    }
}

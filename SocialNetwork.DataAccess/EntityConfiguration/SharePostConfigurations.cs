using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class SharePostConfigurations : IEntityTypeConfiguration<SharePost>
    {
        public void Configure(EntityTypeBuilder<SharePost> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.SharePosts)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.Post)
                .WithMany(x => x.SharePosts)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}

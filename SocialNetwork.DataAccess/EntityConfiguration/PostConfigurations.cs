using SocialNetwork.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class PostConfigurations : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasOne(p => p.Author)
                .WithMany(a => a.Posts)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(p => p.Content)
                .HasColumnType("nvarchar(MAX)");

            builder.HasOne(x => x.Group)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasOne(x => x.SharePost)
                .WithOne()
                .HasForeignKey<Post>(x => x.SharePostId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasIndex(x => x.SharePostId)
                .IsUnique(false);

            builder.Property(x => x.Access).HasColumnType("int").HasDefaultValue(PostAccess.PUBLIC);

        }
    }
}

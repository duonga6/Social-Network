using SocialNetwork.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.Property(p => p.Title)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(p => p.Content)
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class FriendshipConfigurations : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.HasOne(f => f.RequestUser)
                .WithMany(u => u.Friendships1)
                .HasForeignKey(f => f.RequestUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(f => f.TargetUser)
                .WithMany(u => u.Friendships2)
                .HasForeignKey(f => f.TargetUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(f => f.Status)
                .IsRequired();


        }
    }
}

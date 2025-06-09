using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Persistence.EntityConfigurations
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
        }
    }
}

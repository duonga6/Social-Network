using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class NotificationConfigurations : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(n => n.Content)
                .IsRequired();

            builder.HasOne(n => n.TargetUser)
                .WithMany(u => u.NotificationsSend)
                .HasForeignKey(n => n.TargetUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(n => n.FromUser)
                .WithMany(u => u.NotificationsReceive)
                .HasForeignKey(n => n.FromUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}

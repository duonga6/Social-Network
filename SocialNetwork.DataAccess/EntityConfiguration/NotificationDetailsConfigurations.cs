using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class NotificationDetailsConfigurations : IEntityTypeConfiguration<NotificationDetails>
    {
        public void Configure(EntityTypeBuilder<NotificationDetails> builder)
        {
            builder.HasOne(x => x.Author)
                .WithMany(x => x.NotificationsSend)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.Notification)
                .WithOne(x => x.NotificationDetail)
                .HasForeignKey<NotificationDetails>(x => x.NotificationId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.Content).IsRequired();

        }
    }
}

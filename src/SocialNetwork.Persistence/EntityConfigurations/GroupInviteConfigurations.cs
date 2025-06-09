using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Persistence.EntityConfigurations
{
    public class GroupInviteConfigurations : IEntityTypeConfiguration<GroupInvite>
    {
        public void Configure(EntityTypeBuilder<GroupInvite> builder)
        {
            builder.Property(x => x.AdminAccepted).IsRequired();

            builder.HasIndex(x => new
            {
                x.UserId,
                x.GroupId,
            }).IsUnique();

            builder.HasOne(x => x.User)
                .WithMany(x => x.GroupInvites)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.CreatedUser)
                .WithMany(x => x.GroupInvitesCreate)
                .HasForeignKey(x => x.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.Group)
                .WithMany(x => x.GroupInvites)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}

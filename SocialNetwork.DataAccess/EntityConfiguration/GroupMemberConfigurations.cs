using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class GroupMemberConfigurations : IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.GroupMembers)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.Group)
                .WithMany(x => x.GroupMembers)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasIndex(x => new
            {
                x.GroupId,
                x.UserId,
            }).IsUnique();

            builder.HasIndex(x => x.CreatedDate);
        }
    }
}

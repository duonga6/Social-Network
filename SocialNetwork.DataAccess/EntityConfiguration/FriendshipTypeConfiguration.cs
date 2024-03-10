using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class FriendshipTypeConfiguration : IEntityTypeConfiguration<FriendshipType>
    {
        public void Configure(EntityTypeBuilder<FriendshipType> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            var dataDefault = new List<FriendshipType>
            {
                new() { Id = 1, Name = "Pending" },
                new() { Id = 2, Name = "Accepted"},
                new() { Id = 3, Name = "Blocked" },
            };

            builder.HasData(dataDefault);
        }
    }
}

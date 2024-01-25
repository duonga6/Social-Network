using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Utilities.Enum;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class MessageTypeConfiguration : IEntityTypeConfiguration<MessageType>
    {
        public void Configure(EntityTypeBuilder<MessageType> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(20)
                .IsRequired();

            var dataDefault = new List<MessageType>
            {
                new()
                {
                    Id = 1,
                    Name = "Text"
                },
                new()
                {
                    Id = 2,
                    Name = "Video"
                },
                new()
                {
                    Id = 3,
                    Name = "Image"
                }
            };

            builder.HasData(dataDefault);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class MediaTypeConfiguration : IEntityTypeConfiguration<MediaType>
    {
        public void Configure(EntityTypeBuilder<MediaType> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            var defaultData = new List<MediaType>
            {
                new()
                {
                    Id = 1,
                    Name = "Text",
                },
                new()
                {
                    Id = 2,
                    Name = "Image",
                },
                new()
                {
                    Id = 3,
                    Name = "Video"
                },
                new()
                {
                    Id = 4,
                    Name = "File"
                },
                new()
                {
                    Id = 5,
                    Name = "Hyper link"
                }
            };

            builder.HasData(defaultData);
        }
    }
}

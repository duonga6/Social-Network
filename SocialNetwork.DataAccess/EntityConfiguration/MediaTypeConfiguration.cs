using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Utilities.Enum;

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
                    Id = (int)MediaTypeEnum.Text,
                    Name = "Text",
                },
                new()
                {
                    Id = (int)MediaTypeEnum.Image,
                    Name = "Image",
                },
                new()
                {
                    Id = (int)MediaTypeEnum.Video,
                    Name = "Video"
                },
                new()
                {
                    Id = (int)MediaTypeEnum.File,
                    Name = "File"
                },
                new()
                {
                    Id = (int)MediaTypeEnum.HyperLink,
                    Name = "Hyper link"
                }
            };

            builder.HasData(defaultData);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Enums;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            var dataDefault = new List<Gender>
            {
                new()
                {
                    Id = 1,
                    Name = "Female"
                },
                new()
                {
                    Id = 2,
                    Name = "Male"
                }
            };

            builder.HasData(dataDefault);
        }
    }
}

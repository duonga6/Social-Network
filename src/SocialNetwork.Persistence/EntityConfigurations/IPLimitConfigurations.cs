using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Persistence.EntityConfigurations
{
    public class IPLimitConfigurations : IEntityTypeConfiguration<IPLimit>
    {
        public void Configure(EntityTypeBuilder<IPLimit> builder)
        {
            builder.HasIndex(x => x.IpAddress).IsUnique();
        }
    }
}

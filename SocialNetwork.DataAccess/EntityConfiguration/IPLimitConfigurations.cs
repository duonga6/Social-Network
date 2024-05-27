using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    public class IPLimitConfigurations : IEntityTypeConfiguration<IPLimit>
    {
        public void Configure(EntityTypeBuilder<IPLimit> builder)
        {
            builder.HasIndex(x => x.IpAddress).IsUnique();
        }
    }
}

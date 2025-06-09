using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Enums;

namespace SocialNetwork.Persistence.EntityConfigurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role() { Id = 1, RoleName = RoleType.SuperAdministrator.ToString()},
                new Role() { Id = 2, RoleName = RoleType.SuperAdministrator.ToString()},
                new Role() { Id = 3, RoleName = RoleType.SuperAdministrator.ToString()}
            );
        }
    }
}

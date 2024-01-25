using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.DataAccess.Utilities.Roles;

namespace SocialNetwork.DataAccess.EntityConfiguration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole() { Name = RoleName.Administrator, NormalizedName = RoleName.Administrator.ToUpper() },
                new IdentityRole() { Name = RoleName.User, NormalizedName = RoleName.User.ToUpper() }
            );
        }
    }
}

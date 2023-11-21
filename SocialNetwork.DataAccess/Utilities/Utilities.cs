using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Utilities.Roles;

namespace SocialNetwork.DataAccess.Utilities
{
    public static class Utilities
    {
        public static void AddDefaultReactionTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reaction>().HasData(
                new Reaction { Name = "Like", Code = 1 },
                new Reaction { Name = "Love", Code = 2 },
                new Reaction { Name = "Haha", Code = 3 },
                new Reaction { Name = "Wow", Code = 4 },
                new Reaction { Name = "Sad", Code = 5 },
                new Reaction { Name = "Angry", Code = 6 }
            );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = RoleName.Administrator, NormalizedName = RoleName.Administrator.ToUpper()},
                new IdentityRole() { Name = RoleName.User, NormalizedName = RoleName.User.ToUpper()}
            );
        }
    }
}

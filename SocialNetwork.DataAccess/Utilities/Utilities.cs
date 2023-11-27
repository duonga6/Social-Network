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
                new Reaction { Id = 1, Name = "Like"},
                new Reaction { Id = 2, Name = "Love" },
                new Reaction { Id = 3, Name = "Haha" },
                new Reaction { Id = 4, Name = "Wow" },
                new Reaction { Id = 5, Name = "Sad" },
                new Reaction { Id = 6, Name = "Angry" }
            );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = RoleName.Administrator, NormalizedName = RoleName.Administrator.ToUpper()},
                new IdentityRole() { Name = RoleName.User, NormalizedName = RoleName.User.ToUpper()}
            );
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Repositories.Concrete;
using SocialNetwork.DataAccess.Repositories.Abstract;
using SocialNetwork.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;
using SocialNetwork.DataAccess.Services;

namespace SocialNetwork.DataAccess
{
    public static class RegistrationDataAccess
    {
        public static void AddServicesDAL(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

                // Sign settings
                options.SignIn.RequireConfirmedEmail = true;
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Redis
            var redisConnectionString = configuration.GetConnectionString("Redis");
            services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(redisConnectionString));
            services.AddStackExchangeRedisCache(option => option.Configuration = redisConnectionString);
            services.AddSingleton<ICacheService, CacheService>();
        }
    }
}

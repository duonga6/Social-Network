using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Business.Services.Implements;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.Business.Settings;

namespace SocialNetwork.Business
{
    public static class RegistrationBusiness
    {
        public static void AddServicesBLL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));

            services.AddScoped<IReactionService, ReactionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostCommentService, PostCommentService>();
            services.AddScoped<IFriendshipService, FriendshipService>();
        }
    }
}

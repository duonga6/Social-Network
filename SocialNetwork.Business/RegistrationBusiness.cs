﻿using Microsoft.Extensions.Configuration;
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
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            services.AddScoped<IReactionService, ReactionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostCommentService, PostCommentService>();
            services.AddScoped<IFriendshipService, FriendshipService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddTransient<IMailService, MailService>();
            services.AddScoped<IMediaTypeService, MediaTypeService>();
            services.AddScoped<IPostReactionService, PostReactionService>();
            services.AddScoped<ICommentReactionService, CommentReactionService>();
        }
    }
}

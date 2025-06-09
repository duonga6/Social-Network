using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Application.Common.Behaviors;

namespace SocialNetwork.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection ApplicationRegistration(this IServiceCollection service)
        {
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            return service;
        }
    }
}

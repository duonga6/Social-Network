using SocialNetwork.API.Infrastructure.SignalR;

namespace SocialNetwork.API.Infrastructure.Extensions;

public static class SignalRExtension
{
    public static void RegistrationSignalR(this IServiceCollection services)
    {
        services.AddSignalR();
        services.AddSingleton<ConnectionManagementService>();
    }

    public static void RegistrationHub(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<CenterHub>("/chathub");
        });
    }
}

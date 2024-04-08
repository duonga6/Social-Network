using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Interfaces;

namespace SocialNetwork.API.Infrastructure.SignalR
{
    public class HubControl : IHubControl
    {
        private readonly IHubContext<CenterHub> _hubContext;
        private readonly ConnectionManagementService _connectionManagement;

        public HubControl(IHubContext<CenterHub> hubContext, ConnectionManagementService connectionManagement)
        {
            _hubContext = hubContext;
            _connectionManagement = connectionManagement;
        }

        public async Task NewNotification(string userId, GetNotificationResponse notification)
        {
            var connectionIds = _connectionManagement.GetConnectionId(userId);

            if (connectionIds.Count > 0)
            {
                foreach (var connectionId in connectionIds)
                {
                    var clientProxy = _hubContext.Clients.Clients(connectionId);

                    if (clientProxy != null)
                    {
                        await clientProxy.SendAsync("NewNotification", notification);
                    }
                }
            }
        }
    }

}

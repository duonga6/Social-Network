using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.API.Infrastructure.SignalR
{
    public class HubControl : IHubControl
    {
        private readonly IHubContext<CenterHub> _hubContext;
        private readonly ConnectionManagementService _connectionManagement;
        private readonly ILogger _logger;

        public HubControl(IHubContext<CenterHub> hubContext, ConnectionManagementService connectionManagement, ILogger<HubControl> logger)
        {
            _hubContext = hubContext;
            _connectionManagement = connectionManagement;
            _logger = logger;
        }

        public async Task ChangeConversationName(List<string> userIds, GetConversationResponse conversation)
        {
            foreach (var id in userIds)
            {
                var connectionIds = _connectionManagement.GetConnectionId(id);
                if (connectionIds != null)
                {
                    foreach (var connectionId in connectionIds)
                    {
                        var clientProxy = _hubContext.Clients.Clients(connectionId);

                        if (clientProxy != null)
                        {
                            await clientProxy.SendAsync("ChangeConversationName", conversation);
                        }
                    }
                }
            }
        }

        public async Task NewMessage(List<string> userIds, GetMessageResponse message)
        {
            foreach (var id in userIds)
            {
                var connectionIds = _connectionManagement.GetConnectionId(id);
                if (connectionIds != null)
                {
                    foreach(var connectionId in connectionIds)
                    {
                        var clientProxy = _hubContext.Clients.Clients(connectionId);

                        if (clientProxy != null)
                        {
                            await clientProxy.SendAsync("NewMessage", message);
                        }
                    }
                }
            }
        }

        public async Task NewNotification(string userId, GetNotificationResponse notification)
        {
            var connectionIds = _connectionManagement.GetConnectionId(userId);

            if (connectionIds != null)
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

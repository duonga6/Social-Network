using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SocialNetwork.API.Utilities;
using SocialNetwork.Business.DTOs.Notification.Responses;
using SocialNetwork.Business.Services.Interfaces;

namespace SocialNetwork.API.Infrastructure.SignalR
{
    [Authorize]
    public class CenterHub : Hub
    {
        private readonly ConnectionManagementService _connectionManagement;
        private readonly ILogger _logger;
        private string? UserId
        {
            get { return Context.User?.GetUserId(); }
        }

        public CenterHub(ConnectionManagementService connectionManagement, ILogger<CenterHub> logger)
        {
            _connectionManagement = connectionManagement;
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            if (UserId != null)
            {
                _connectionManagement.AddConnection(UserId, Context.ConnectionId);

                var listConnected = string.Join("\n\t\t", _connectionManagement.GetConnectionId(UserId));
                _logger.LogInformation($"User: {UserId} connected with connection id: {Context.ConnectionId}\nList connection id of user:\n{listConnected}");
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (UserId != null)
            {
                _connectionManagement.RemoveConnection(UserId, Context.ConnectionId);
                var listConnected = string.Join("\n\n\n", _connectionManagement.GetConnectionId(UserId));
                _logger.LogInformation($"User: {UserId} disconnected with connection id: {Context.ConnectionId}\n\nList connection id of user:\n{listConnected}");
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendAll(string message)
        {

            await Clients.All.SendAsync("ReceiveAllMessage", message);
        }

        
    }
}

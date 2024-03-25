using Microsoft.AspNetCore.SignalR;
using SocialNetwork.API.Utilities;

namespace SocialNetwork.API.Infrastructure.SignalR
{
    public class CenterHub : Hub
    {
        private readonly ConnectionManagementService _connectionManagement;
        private readonly ILogger _logger;
        private string? UserId
        {
            get { return Context.User?.GetUserId(); }
        }

        public CenterHub(ConnectionManagementService connectionManagement, ILogger logger)
        {
            _connectionManagement = connectionManagement;
            _logger = logger;
        }

        public override Task OnConnectedAsync()
        {
            if (UserId != null)
            {
                _connectionManagement.AddConnection(UserId, Context.ConnectionId);

                var listConnected = string.Join("\n\n\n", _connectionManagement.GetConnectionId(UserId));
                _logger.LogInformation($"User: {UserId} connected with connection id: {Context.ConnectionId}\n\nList connection id of user:\n{listConnected}");
            }

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if (UserId != null)
            {
                _connectionManagement.RemoveConnection(UserId, Context.ConnectionId);
                var listConnected = string.Join("\n\n\n", _connectionManagement.GetConnectionId(UserId));
                _logger.LogInformation($"User: {UserId} disconnected with connection id: {Context.ConnectionId}\n\nList connection id of user:\n{listConnected}");
            }

            return base.OnDisconnectedAsync(exception);
        }
    }
}

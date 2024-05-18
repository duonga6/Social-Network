using Microsoft.AspNetCore.SignalR;
using Microsoft.VisualBasic;
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

        private async Task EventSend(ICollection<string> userIds, object data, string eventName)
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
                            _logger.LogInformation(eventName + data);
                            await clientProxy.SendAsync(eventName, data);
                        }
                    }
                }
            }
        }

        public async Task ChangeConversationName(ICollection<string> userIds, GetConversationResponse conversation)
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

        public async Task DeleteConversation(ICollection<string> userIds, Guid conversationId)
        {
            await EventSend(userIds, conversationId, "DeleteConversation");
        }

        public async Task NewGroupConversation(ICollection<string> userIds, GetConversationResponse conversation)
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
                            await clientProxy.SendAsync("NewGroupConversation", conversation);
                        }
                    }
                }
            }
        }

        public async Task NewMessage(ICollection<string> userIds, GetMessageResponse message)
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

        public async Task FriendIsActive(ICollection<string> userIds, string userId)
        {
            await EventSend(userIds, userId, "FriendIsActive");
        }

        public async Task FriendIsInActive(ICollection<string> userIds, string userId)
        {
            await EventSend(userIds, userId, "FriendInActive");
        }

        public List<string>? GetFriendActive(string userId)
        {
            return _connectionManagement.GetFriendActive(userId);
        }

        public async Task ChangeConversationImage(ICollection<string> userIds, GetConversationResponse conversation)
        {
            await EventSend(userIds, conversation, "ChangeImageConversation");
        }

        public int GetActivingUser()
        {
            return _connectionManagement.CountUser();
        }
    }

}

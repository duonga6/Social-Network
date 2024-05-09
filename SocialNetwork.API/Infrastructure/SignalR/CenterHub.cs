using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SocialNetwork.API.Utilities;
using SocialNetwork.Business.DTOs.Responses;
using SocialNetwork.Business.Services.Interfaces;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.API.Infrastructure.SignalR
{
    [Authorize]
    public class CenterHub : Hub
    {
        private readonly ConnectionManagementService _connectionManagement;
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubControl _hubControl;
        private string? UserId
        {
            get { return Context.User?.GetUserId(); }
        }

        private HashSet<string> FriendIds = new();

        public CenterHub(ConnectionManagementService connectionManagement, ILogger<CenterHub> logger, IUnitOfWork unitOfWork, IHubControl hubControl)
        {
            _connectionManagement = connectionManagement;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _hubControl = hubControl;
        }

        public override async Task OnConnectedAsync()
        {
            if (UserId != null)
            {
                _connectionManagement.AddConnection(UserId, Context.ConnectionId);

                var listConnected = string.Join("\n\t\t", _connectionManagement.GetConnectionId(UserId) ?? new());
                _logger.LogInformation($"User: {UserId} connected with connection id: {Context.ConnectionId}\nList connection id of user:\n{listConnected}");

                FriendIds = (await _unitOfWork.FriendshipRepository.GetFriendIds(UserId)).ToHashSet();
                await _hubControl.FriendIsActive(FriendIds, UserId);
                _connectionManagement.AddFriendActive(UserId, FriendIds);

            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (UserId != null)
            {
                _connectionManagement.RemoveConnection(UserId, Context.ConnectionId);
                var listConnected = string.Join("\n\n\n", _connectionManagement.GetConnectionId(UserId)?.ToArray<string?>() ?? new string[] {});
                _logger.LogInformation($"User: {UserId} disconnected with connection id: {Context.ConnectionId}\n\nList connection id of user:\n{listConnected}");

                await _hubControl.FriendIsInActive(FriendIds, UserId);
                _connectionManagement.RemoveFriendActive(UserId, FriendIds);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}

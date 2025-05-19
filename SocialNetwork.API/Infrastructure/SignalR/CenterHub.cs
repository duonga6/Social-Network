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

                
                if (_connectionManagement.GetFriendIds(UserId) == null)
                {
                    _connectionManagement.AddConnectionFriend(UserId, (await _unitOfWork.FriendshipRepository.GetFriendIdsAsync(UserId)).ToHashSet());
                }

                var friendIds = _connectionManagement.GetFriendIds(UserId);


                await _hubControl.FriendIsActive(_connectionManagement.GetFriendIds(UserId) ?? new(), UserId);
                _connectionManagement.AddFriendActive(UserId, friendIds ?? new());

            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (UserId != null)
            {
                _connectionManagement.RemoveConnection(UserId, Context.ConnectionId);
                var listConnected = string.Join("\n\n\n", _connectionManagement.GetConnectionId(UserId) ?? new());
                _logger.LogInformation($"User: {UserId} disconnected with connection id: {Context.ConnectionId}\n\nList connection id of user:\n{listConnected}");

                var friendIds = _connectionManagement.GetFriendIds(UserId);
                await _hubControl.FriendIsInActive(friendIds ?? new(), UserId);
                _connectionManagement.RemoveFriendActive(UserId, friendIds ?? new());
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}

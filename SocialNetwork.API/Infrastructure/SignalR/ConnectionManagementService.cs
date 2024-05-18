namespace SocialNetwork.API.Infrastructure.SignalR
{
    public class ConnectionManagementService
    {
        private readonly Dictionary<string, HashSet<string>> connections;
        private readonly Dictionary<string, HashSet<string>> connectionFriends;
        private readonly Dictionary<string, HashSet<string>> friendActives;
        private readonly ILogger _logger;

        public ConnectionManagementService(ILogger<ConnectionManagementService> logger)
        {
            connections = new();
            friendActives = new();
            connectionFriends = new();
            _logger = logger;
        }

        public int CountUser() => connections.Count;

        public void AddConnection(string userId, string connectionId)
        {
            try
            {
                if (!connections.ContainsKey(userId))
                {
                    connections[userId] = new();
                }

                connections[userId].Add(connectionId);


            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void RemoveConnection(string userId, string connectionId)
        {
            try
            {
                if (connections.ContainsKey(userId))
                {
                    connections[userId].Remove(connectionId);


                    if (connections[userId].Count == 0)
                    {
                        connections.Remove(userId);
                    }
                }

            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public HashSet<string> GetUserIdConnected()
        {
            return connections.Keys.ToHashSet();
        }

        public HashSet<string>? GetConnectionId(string userId)
        {
            return connections.ContainsKey(userId) ? connections[userId] : null;
        }
    
        public void AddFriendActive(string userId, HashSet<string> friendList)
        {
            foreach (var friendId in friendList)
            {
                if (!friendActives.ContainsKey(friendId))
                {
                    friendActives[friendId] = new() { userId };
                } else
                {
                    friendActives[friendId].Add(userId);
                }
            }
        }

        public void RemoveFriendActive(string userId, HashSet<string> friendList)
        {
            foreach (var friendId in friendList)
            {
                if (friendActives.ContainsKey(friendId))
                {
                    friendActives[friendId].Remove(userId);
                }
            }
        }

        public void RemoveFriendActive(string userId, string friendId)
        {
            if (friendActives.ContainsKey(friendId))
            {
                friendActives[friendId].Remove(userId);
            }
        }

        public List<string>? GetFriendActive(string userId)
        {
            if (friendActives.ContainsKey(userId))
            {
                return friendActives[userId].ToList();
            }

            return null;
        }

        public void AddConnectionFriend(string userId, HashSet<string> friendIds)
        {
            connectionFriends[userId] = friendIds;
        }

        public void RemoveConnectionFriend(string userId)
        {
            connectionFriends.Remove(userId);
        }

        public HashSet<string>? GetFriendIds(string userId)
        {
            if (connectionFriends.ContainsKey(userId))
            {
                return connectionFriends[userId];
            }

            return null;
        }
    }
}

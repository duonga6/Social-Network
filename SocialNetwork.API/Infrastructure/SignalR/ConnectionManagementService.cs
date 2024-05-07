namespace SocialNetwork.API.Infrastructure.SignalR
{
    public class ConnectionManagementService
    {
        private readonly Dictionary<string, HashSet<string>> connections;
        private readonly ILogger _logger;

        public ConnectionManagementService(ILogger<ConnectionManagementService> logger)
        {
            connections = new();
            _logger = logger;
        }

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

        public HashSet<string>? GetConnectionId(string userId)
        {
            return connections.ContainsKey(userId) ? connections[userId] : null;
        }
    }
}

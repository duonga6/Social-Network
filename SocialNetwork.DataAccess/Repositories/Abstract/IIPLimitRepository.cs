using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IIPLimitRepository : IGenericRepository<IPLimit, Guid>
    {
        Task<bool> CheckIPRegistered(string ipaddress);
    }
}

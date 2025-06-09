namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface IIPLimitRepository : IRepositoryBase<IPLimit, Guid>
    {
        Task<bool> IsIPRegisteredAsync(string ipaddress);
    }
}

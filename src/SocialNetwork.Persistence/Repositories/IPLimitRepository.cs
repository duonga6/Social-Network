namespace SocialNetwork.Persistence.Repositories
{
    public class IPLimitRepository : RepositoryBase<IPLimit, Guid>, IIPLimitRepository
    {
        public IPLimitRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public Task<bool> IsIPRegisteredAsync(string ipaddress)
        {
            throw new NotImplementedException();
        }
    }
}

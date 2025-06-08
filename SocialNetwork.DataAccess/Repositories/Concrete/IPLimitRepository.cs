using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class IPLimitRepository : GenericRepository<IPLimit, Guid>, IIPLimitRepository
    {
        public IPLimitRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public async Task<bool> CheckIPRegistered(string ipaddress)
        {
            var ipAddress = await _dbSet.FirstOrDefaultAsync(x => x.IpAddress == ipaddress);

            if (ipAddress != null)
            {
                if (ipAddress.UpdatedAt.Date < DateTime.UtcNow.Date)
                {
                    ipAddress.UpdatedAt = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                    return true;
                }

                return false;
            }

            _dbSet.Add(new IPLimit
            {
                IpAddress = ipaddress
            });
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

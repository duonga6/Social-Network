using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    internal class RoleRepository : GenericRepository<IdentityRole>, IRoleRepository
    {
        public RoleRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task<ICollection<IdentityRole>> GetAll()
        {
            return await _dbSet.AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();
        }
    }
}

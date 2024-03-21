using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class ReactionRepository : GenericRepository<Reaction, int>, IReactionRepository
    {
        public ReactionRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public async Task<Reaction> GetById(int id)
        {
            return await _dbSet.FirstAsync(x => x.Id == id);
        }

        public override async Task<ICollection<Reaction>> GetAll(bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().ToListAsync();
            }

            return await _dbSet.ToListAsync();
        }

        public override async Task Update(Reaction entity)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (result != null)
            {
                result.Name = entity.Name;
                result.UpdatedAt = DateTime.UtcNow;
            } 
        }

    }
}

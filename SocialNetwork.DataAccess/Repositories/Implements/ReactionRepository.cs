using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;
using System.Linq;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class ReactionRepository : GenericRepository<Reaction>, IReactionRepository
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

        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null) { return false; }

                _dbSet.Remove(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} error function: Delete", typeof(ReactionRepository));
                throw;
            }
        }

        public override async Task<bool> Update(Reaction entity)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (result == null) return false;

                result.Name = entity.Name;

                result.UpdatedAt = DateTime.UtcNow;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} error function: Update", typeof(ReactionRepository));
                throw;
            }
        }
    }
}

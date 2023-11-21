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

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null) { return false; }

                entity.Status = 0;
                entity.UpdatedAt = DateTime.UtcNow;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} error function: Delete", typeof(ReactionRepository));
                throw;
            }
        }

        public override async Task<ICollection<Reaction>> GetAll()
        {
            try
            {
                var entity = await _dbSet.Where(x => x.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.Code)
                .ToListAsync();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} error function: GetAll", typeof(ReactionRepository));
                throw;
            }
        }

        public override async Task<bool> Update(Reaction entity)
        {
            try
            {
                var result = await _dbSet.FindAsync(entity.Id);
                if (result == null) return false;

                result.Code = entity.Code;
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

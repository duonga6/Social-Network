using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;
using System.Linq;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class ReactionRepository : GenericRepository<Reaction, int>, IReactionRepository
    {
        public ReactionRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task UpdateAsync(Reaction entity)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (result != null)
            {
                result.Name = entity.Name;
                result.ModifiedDate = DateTime.UtcNow;
            } 
        }

    }
}

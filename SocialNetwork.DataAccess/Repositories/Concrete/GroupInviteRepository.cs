using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class GroupInviteRepository : GenericRepository<GroupInvite, Guid>, IGroupInviteRepository
    {
        public GroupInviteRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task Update(GroupInvite invite)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == invite.Id);
            if (entity != null)
            {
                entity.UserAccepted = invite.UserAccepted;
                entity.AdminAccepted = invite.AdminAccepted;
                entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.DataAccess.Repositories.Implements
{
    public class GroupRepository : GenericRepository<Group, Guid>, IGroupRepository
    {
        public GroupRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task Update(Group entity)
        {
            var group = await _dbSet.FindAsync(entity.Id);

            group.Name = entity.Name;
            group.Description = entity.Description;
            group.IsPublic = entity.IsPublic;
        }

        public override async Task Delete(Guid Id)
        {
            var group = await _dbSet.FindAsync(Id);
            group.Status = 0;
        }
    }
}

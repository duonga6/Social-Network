using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class GroupRepository : SoftDeleteRepository<Group, Guid>, IGroupRepository
    {
        public GroupRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }
        public override async Task UpdateAsync(Group entity)
        {
            var group = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);

            group.Name = entity.Name;
            group.Description = entity.Description;
            group.IsPublic = entity.IsPublic;
            group.PreCensored = entity.PreCensored;
            group.CoverImage = entity.CoverImage;
        }
        public async Task IncreaseMemberAsync(Guid groupId)
        {
            var group = await _dbSet.FirstOrDefaultAsync(x => x.Id == groupId);
            group.TotalMember++;
        }
        public async Task ReduceMemberAsync(Guid groupId)
        {
            var group = await _dbSet.FirstOrDefaultAsync(x => x.Id == groupId);
            if (group != null)
            {
                group.TotalMember--;
            }
        }
    }
}

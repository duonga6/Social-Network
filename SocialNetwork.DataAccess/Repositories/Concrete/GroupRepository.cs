using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Entities;
using SocialNetwork.DataAccess.Repositories.Abstract;

namespace SocialNetwork.DataAccess.Repositories.Concrete
{
    public class GroupRepository : GenericRepository<Group, Guid>, IGroupRepository
    {
        public GroupRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task Update(Group entity)
        {
            var group = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);

            group.Name = entity.Name;
            group.Description = entity.Description;
            group.IsPublic = entity.IsPublic;
            group.PreCensored = entity.PreCensored;
            group.CoverImage = entity.CoverImage;
        }

        public override async Task Delete(Guid Id)
        {
            var group = await _dbSet.FirstOrDefaultAsync(x => x.Id == Id);
            group.Status = 0;
        }

        public async Task PlusMember(Guid groupId)
        {
            var group = await _dbSet.FirstOrDefaultAsync(x => x.Id == groupId);
            group.TotalMember++;
        }

        public async Task MinusMember(Guid groupId)
        {
            var group = await _dbSet.FirstOrDefaultAsync(x => x.Id == groupId);
            if (group != null)
            {
                group.TotalMember--;
            }
        }
    }
}

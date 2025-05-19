using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IGroupRepository : ISoftDeleteRepository<Group, Guid>
    {
        Task IncreaseMemberAsync(Guid groupId);
        Task ReduceMemberAsync(Guid groupId);
    }
}

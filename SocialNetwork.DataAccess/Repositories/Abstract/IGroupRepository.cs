using SocialNetwork.DataAccess.Entities;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IGroupRepository : IGenericRepository<Group, Guid>
    {
        Task PlusMember(Guid groupId);
    }
}

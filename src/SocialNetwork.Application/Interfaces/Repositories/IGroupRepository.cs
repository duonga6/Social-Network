namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface IGroupRepository : IRepositoryBase<Group, Guid>
    {
        Task IncreaseMemberAsync(Guid groupId);
        Task ReduceMemberAsync(Guid groupId);
    }
}

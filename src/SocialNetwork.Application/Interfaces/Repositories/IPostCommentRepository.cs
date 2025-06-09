namespace SocialNetwork.Application.Interfaces.Repositories
{
    public interface IPostCommentRepository : IRepositoryBase<PostComment, Guid>
    {
        Task<ICollection<PostComment>> GetByPostAsync(Guid postId);
    }
}

namespace SocialNetwork.Persistence.Repositories
{
    public class PostCommentRepository : RepositoryBase<PostComment, Guid>, IPostCommentRepository
    {
        public PostCommentRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public Task<ICollection<PostComment>> GetByPostAsync(Guid postId)
        {
            throw new NotImplementedException();
        }
    }
}

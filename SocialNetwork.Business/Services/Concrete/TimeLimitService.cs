namespace SocialNetwork.Business.Services.Concrete
{
    public class TimeLimitService
    {
        // Miliseconds
        public int TimeLimitPost { get; private set; } = 5 * 60 * 1000;
        public int TimeLimitComment { get; private set; } = 1 * 60 * 1000;

        private Dictionary<string, DateTime> LimitPost;
        private Dictionary<string, DateTime> LimitComment;

        public TimeLimitService()
        {
            LimitPost = new();
            LimitComment = new();
        }


        public bool CheckLimitCreatePost(string userId)
        {
            if (!LimitPost.ContainsKey(userId))
            {
                LimitPost[userId] = DateTime.Now;
                return true;
            }

            return DateTime.Now.Millisecond - LimitPost[userId].Millisecond >= TimeLimitPost;
        }

        public bool CheckLimitCreateComment(string userId, Guid postId)
        {
            string key = userId + "-" + postId.ToString();

            if (!LimitComment.ContainsKey(key))
            {
                LimitComment[key] = DateTime.Now;
                return true;
            }

            return DateTime.Now.Millisecond - LimitComment[key].Millisecond >= TimeLimitComment;
        }
    }
}

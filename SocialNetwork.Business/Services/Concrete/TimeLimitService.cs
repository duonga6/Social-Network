namespace SocialNetwork.Business.Services.Concrete
{
    public class TimeLimitService
    {
        public int TimeLimitPost { get; private set; } = 5;
        public int TimeLimitComment { get; private set; } = 1;

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

            return DateTime.Now.Millisecond - LimitPost[userId].Millisecond >= TimeLimitPost * 60 * 1000;
        }

        public bool CheckLimitCreateComment(string userId, Guid postId)
        {
            string key = userId + "-" + postId.ToString();

            if (!LimitComment.ContainsKey(key))
            {
                LimitComment[key] = DateTime.Now;
                return true;
            }

            return DateTime.Now.Millisecond - LimitComment[key].Millisecond >= TimeLimitComment * 60 * 1000;
        }

        public void SetTimeCreatePost(string userId)
        {
            LimitPost[userId] = DateTime.Now;
        }

        public void SetTimeCreateComment(string userId, Guid postId)
        {
            LimitPost[userId + "-" + postId.ToString()] = DateTime.Now;
        }
    }
}

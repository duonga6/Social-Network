using SocialNetwork.DataAccess.Entities.Base;

namespace SocialNetwork.DataAccess.Entities
{
    public class Gender : BaseEntity<int>
    {
        public string Name { set; get; }

        public virtual ICollection<User> Users { set; get; }
    }
}

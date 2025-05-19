using Newtonsoft.Json;

namespace SocialNetwork.DataAccess.Entities
{
    public class Group : EntityAuditBase<Guid>
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public string CreatedId { set; get; }
        public bool PreCensored { set; get; }
        public bool IsPublic { set; get; }
        public string CoverImage { set; get; }
        public int TotalMember { set; get; }

        public virtual User CreatedUser { set; get; }
        [JsonIgnore]
        public virtual ICollection<Post> Posts { set; get; }
        [JsonIgnore]
        public virtual ICollection<GroupMember> GroupMembers { set; get; }
        [JsonIgnore]
        public virtual ICollection<GroupInvite> GroupInvites { get; set; }
    }
}

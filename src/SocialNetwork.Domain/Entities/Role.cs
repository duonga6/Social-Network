namespace SocialNetwork.Domain.Entities;

public class Role : EntityAuditBase<int>
{
    public string RoleName { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
}

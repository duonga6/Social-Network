namespace SocialNetwork.Domain.Abstractions.Entities;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
    DateTimeOffset? DeletedAt { get; set; }

    public void SoftDelete()
    {
        IsDeleted = true;
        DeletedAt = DateTimeOffset.Now;
    }
    public void Restore()
    {
        IsDeleted = false;
        DeletedAt = null;
    }
}

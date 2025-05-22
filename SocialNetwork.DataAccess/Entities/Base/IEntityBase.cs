namespace SocialNetwork.DataAccess.Entities
{
    public interface IEntityBase<TKey>
    {
        TKey Id { get; set; }
    }
}

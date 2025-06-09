namespace SocialNetwork.Domain.Abstractions.Entities;

public interface IUserTracking
{
    Guid CreatedBy { get; set; }
    Guid? ModifiedBy { get; set; }
}

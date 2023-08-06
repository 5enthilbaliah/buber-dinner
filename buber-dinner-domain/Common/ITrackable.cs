namespace BuberDinner.Domain.Common;

public interface ITrackable
{
    DateTime CreatedOn { get; }
    DateTime ModifiedOn { get; }
}
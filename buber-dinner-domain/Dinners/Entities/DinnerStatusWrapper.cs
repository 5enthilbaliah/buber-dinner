namespace BuberDinner.Domain.Dinners.Entities;

using Common;

using Enums;

public class DinnerStatusWrapper : Entity<DinnerStatus>, ITrackable
{
#pragma warning disable CS8618
    private DinnerStatusWrapper()
    {
    }
#pragma warning restore CS8618

    private DinnerStatusWrapper(
        DinnerStatus id,
        string name,
        DateTime createdOn,
        DateTime modifiedOn)
        : base(id)
    {
        Name = name;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
    }

    public string Name { get; }
    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }

    public static DinnerStatusWrapper SpawnOne(
        DinnerStatus id,
        string name,
        DateTime createdOn,
        DateTime modifiedOn)
    {
        return new(id, name, createdOn, modifiedOn);
    }
}
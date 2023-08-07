namespace BuberDinner.Domain.Dinners.Entities;

using Common;

using Enums;

public class ReservationStatusWrapper : Entity<ReservationStatus>, ITrackable
{
#pragma warning disable CS8618
    private ReservationStatusWrapper()
    {
    }
#pragma warning restore CS8618

    private ReservationStatusWrapper(
        ReservationStatus id,
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

    public static ReservationStatusWrapper SpawnOne(
        ReservationStatus id,
        string name,
        DateTime createdOn,
        DateTime modifiedOn)
    {
        return new ReservationStatusWrapper(id, name, createdOn, modifiedOn);
    }
}
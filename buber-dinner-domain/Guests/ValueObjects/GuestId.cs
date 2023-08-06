namespace BuberDinner.Domain.Guests.ValueObjects;

using Common;

public class GuestId : AggregateRootId<Guid>
{
    private GuestId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static GuestId SpawnUniqueOne()
    {
        return new GuestId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
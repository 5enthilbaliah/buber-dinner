namespace BuberDinner.Domain.Guests.ValueObjects;

using Common;

public class GuestId : ValueObject
{
    private GuestId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static GuestId SpawnUniqueOne()
    {
        return new GuestId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
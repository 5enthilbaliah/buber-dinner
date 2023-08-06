namespace BuberDinner.Domain.Guests.ValueObjects;

using Common;

public class GuestRatingId : ValueObject
{
    private GuestRatingId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static GuestRatingId SpawnUniqueOne()
    {
        return new GuestRatingId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
namespace BuberDinner.Domain.Dinners.ValueObjects;

using Common;

public class ReservationId : ValueObject
{
    private ReservationId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static ReservationId SpawnUniqueOne()
    {
        return new ReservationId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static ReservationId SpawnWith(Guid id)
    {
        return new ReservationId(id);
    }
}
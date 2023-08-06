namespace BuberDinner.Domain.Dinners.ValueObjects;

using Common;

public sealed class DinnerId : ValueObject
{
    private DinnerId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static DinnerId SpawnUniqueOne()
    {
        return new DinnerId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
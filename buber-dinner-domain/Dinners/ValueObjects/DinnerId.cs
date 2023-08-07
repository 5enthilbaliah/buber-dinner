namespace BuberDinner.Domain.Dinners.ValueObjects;

using Common;

public sealed class DinnerId : AggregateRootId<Guid>
{
    private DinnerId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static DinnerId SpawnUniqueOne()
    {
        return new DinnerId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static DinnerId SpawnWith(Guid id)
    {
        return new DinnerId(id);
    }
}
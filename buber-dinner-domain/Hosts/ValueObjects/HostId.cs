namespace BuberDinner.Domain.Hosts.ValueObjects;

using Common;

public sealed class HostId : ValueObject
{
    private HostId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static HostId SpawnUniqueOne()
    {
        return new HostId(Guid.NewGuid());
    }

    public static HostId SpawnOne(Guid id)
    {
        return new HostId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
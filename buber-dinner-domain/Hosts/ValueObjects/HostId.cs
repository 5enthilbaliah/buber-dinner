namespace BuberDinner.Domain.Hosts.ValueObjects;

using Common;

public sealed class HostId : AggregateRootId<Guid>
{
    private HostId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static HostId SpawnUniqueOne()
    {
        return new HostId(Guid.NewGuid());
    }

    public static HostId SpawnWith(Guid id)
    {
        return new HostId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
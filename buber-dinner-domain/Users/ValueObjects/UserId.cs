namespace BuberDinner.Domain.Users.ValueObjects;

using Common;

public sealed class UserId : AggregateRootId<Guid>
{
    private UserId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static UserId SpawnUniqueOne()
    {
        return new UserId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
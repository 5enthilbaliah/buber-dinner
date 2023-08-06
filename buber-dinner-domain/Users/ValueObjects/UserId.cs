namespace BuberDinner.Domain.Users.ValueObjects;

using Common;

public sealed class UserId : ValueObject
{
    private UserId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static UserId SpawnUniqueOne()
    {
        return new UserId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
namespace BuberDinner.Domain.Menus.ValueObjects;

using Common;

public sealed class MenuId : ValueObject
{
    private MenuId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MenuId SpawnUniqueOne()
    {
        return new MenuId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
namespace BuberDinner.Domain.Menus.ValueObjects;

using Common;

public class MenuItemId : ValueObject
{
    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MenuItemId SpawnUniqueOne()
    {
        return new MenuItemId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
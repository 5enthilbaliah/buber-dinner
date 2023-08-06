namespace BuberDinner.Domain.Menus.ValueObjects;

using Common;

public sealed class MenuId : AggregateRootId<Guid>
{
    private MenuId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static MenuId SpawnUniqueOne()
    {
        return new MenuId(Guid.NewGuid());
    }

    public static MenuId SpawnWith(Guid id)
    {
        return new MenuId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
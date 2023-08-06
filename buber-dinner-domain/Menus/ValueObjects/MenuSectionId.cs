namespace BuberDinner.Domain.Menus.ValueObjects;

using Common;

public class MenuSectionId : ValueObject
{
    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MenuSectionId SpawnUniqueOne()
    {
        return new MenuSectionId(Guid.NewGuid());
    }

    public static MenuSectionId SpawnWith(Guid id)
    {
        return new MenuSectionId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
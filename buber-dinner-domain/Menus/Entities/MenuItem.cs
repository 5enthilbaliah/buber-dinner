namespace BuberDinner.Domain.Menus.Entities;

using Common;

using ValueObjects;

public class MenuItem : Entity<MenuItemId>
{
#pragma warning disable CS8618
    private MenuItem()
    {
    }
#pragma warning restore CS8618

    private MenuItem(MenuItemId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }

    public static MenuItem SpawnOne(string name, string description)
    {
        return new MenuItem(MenuItemId.SpawnUniqueOne(), name, description);
    }
}
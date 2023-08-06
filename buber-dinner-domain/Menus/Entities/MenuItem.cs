namespace BuberDinner.Domain.Menus.Entities;

using Common;

using ValueObjects;

public class MenuItem : Entity<MenuItemId>
{
    private MenuItem(MenuItemId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }
    public string Description { get; }

    public static MenuItem SpawnOne(string name, string description)
    {
        return new MenuItem(MenuItemId.SpawnUniqueOne(), name, description);
    }
}
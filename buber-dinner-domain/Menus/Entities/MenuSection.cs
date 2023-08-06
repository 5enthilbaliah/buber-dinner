namespace BuberDinner.Domain.Menus.Entities;

using Common;

using ValueObjects;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();

    private MenuSection(MenuSectionId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }
    public string Description { get; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    public static MenuSection SpawnOne(string name, string description)
    {
        return new MenuSection(MenuSectionId.SpawnUniqueOne(), name, description);
    }

    public static MenuSection SpawnOne(
        string name,
        string description,
        List<MenuItem> items)
    {
        var menuSection = new MenuSection(MenuSectionId.SpawnUniqueOne(), name, description);

        if (items.Any())
        {
            menuSection._items.AddRange(items);
        }

        return menuSection;
    }
}
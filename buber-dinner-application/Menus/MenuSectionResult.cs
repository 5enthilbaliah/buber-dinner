namespace BuberDinner.Application.Menus;

public record MenuSectionResult(
    Guid Id,
    string Name,
    string Description,
    List<MenuItemResult> Items);
namespace BuberDinner.Contracts.Menus;

public record CreateMenuItemRequest(
    string Name,
    string Description);
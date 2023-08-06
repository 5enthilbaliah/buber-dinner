namespace BuberDinner.Contracts.Menus;

public record CreateMenuSectionRequest (
    string Name,
    string Description,
    List<CreateMenuItemRequest> Items);
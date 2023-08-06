namespace BuberDinner.Contracts.Menus;

public record CreateMenuRequest(
    string Name,
    string Description,
    List<CreateMenuSectionRequest> Sections);
namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public record CreateMenuSectionCommand(
    string Name,
    string Description,
    List<CreateMenuItemCommand> Items);
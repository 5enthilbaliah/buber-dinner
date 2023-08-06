namespace BuberDinner.Application.Menus.Commands.CreateMenu;

using ErrorOr;

using MediatR;

public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<CreateMenuSectionCommand> Sections) : IRequest<ErrorOr<MenuResult>>;
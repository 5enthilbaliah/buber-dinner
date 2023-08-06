namespace BuberDinner.Application.Menus.Queries.GetMenu;

using ErrorOr;

using MediatR;

public record GetMenuQuery(string HostId, string MenuId)
    : IRequest<ErrorOr<MenuResult>>;
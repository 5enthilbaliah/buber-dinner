namespace BuberDinner.Presentation.Controllers;

using Application.Menus.Commands.CreateMenu;
using Application.Menus.Queries.GetMenu;

using Contracts.Menus;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[Route("hosts/{host_id}/menus")]
public class MenusController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public MenusController(IHttpContextAccessor httpContextAccessor, ISender mediator, IMapper mapper)
        : base(httpContextAccessor)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenuAsync(
        [FromRoute(Name = "host_id")] string hostId,
        CreateMenuRequest request,
        CancellationToken cancellationToken = default)
    {
        var menuResult = await _mediator.Send(
            _mapper.Map<CreateMenuCommand>((request, hostId)),
            cancellationToken).ConfigureAwait(false);

        return menuResult.Match(
            result => Ok(_mapper.Map<MenuResponse>(result)),
            Problem);
    }

    [HttpGet("{menu_id}")]
    public async Task<IActionResult> GetMenuAsync(
        [FromRoute(Name = "host_id")] string hostId,
        [FromRoute(Name = "menu_id")] string menuId,
        CancellationToken cancellationToken = default)
    {
        var menuResult = await _mediator.Send(
            new GetMenuQuery(hostId, menuId),
            cancellationToken).ConfigureAwait(false);

        return menuResult.Match(
            result => Ok(_mapper.Map<MenuResponse>(result)),
            Problem);
    }
}
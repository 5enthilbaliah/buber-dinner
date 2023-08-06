namespace BuberDinner.Presentation.Controllers;

using Application.Menus.Commands.CreateMenu;

using Contracts.Menus;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[Route("hosts/{hostId}/menus")]
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
    public async Task<IActionResult> CreateMenu(
        string hostId,
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
}
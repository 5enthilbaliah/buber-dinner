namespace BuberDinner.Presentation.Controllers;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[Route("[controller]")]
public class DinnersController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public DinnersController(IHttpContextAccessor httpContextAccessor, ISender mediator, IMapper mapper)
        : base(httpContextAccessor)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<IActionResult> ListDinners()
    {
        await Task.CompletedTask;
        return Ok(Array.Empty<string>());
    }
}
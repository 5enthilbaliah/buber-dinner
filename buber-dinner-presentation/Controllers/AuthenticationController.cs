namespace BuberDinner.Presentation.Controllers;

using Application.Authentication.Commands.Register;
using Application.Authentication.Queries.Login;

using Contracts.Authentication;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public AuthenticationController(IHttpContextAccessor httpContextAccessor, ISender mediator, IMapper mapper)
        : base(httpContextAccessor)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var authResult = await _mediator.Send(_mapper.Map<RegisterCommand>(request));

        return authResult.Match(
            result => Ok(_mapper.Map<AuthenticationResponse>(result)),
            Problem);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var loginResult = await _mediator.Send(_mapper.Map<LoginQuery>(request));

        return loginResult.Match(
            result => Ok(_mapper.Map<AuthenticationResponse>(result)),
            Problem);
    }
}
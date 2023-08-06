namespace BuberDinner.Application.Authentication.Queries.Login;

using ErrorOr;

using MediatR;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
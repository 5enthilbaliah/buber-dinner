namespace BuberDinner.Application.Authentication;

using Domain.Users;

public record AuthenticationResult(
    User User,
    string Token);
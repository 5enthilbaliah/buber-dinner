namespace BuberDinner.Application.Common.Interfaces.Authentication;

using Domain.Users;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
namespace BuberDinner.Application.Common.Interfaces.Persistence;

using Domain.Users;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
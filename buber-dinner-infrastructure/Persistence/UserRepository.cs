namespace BuberDinner.Infrastructure.Persistence;

using Application.Common.Interfaces.Persistence;

using Domain.Users;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new();

    public User? GetUserByEmail(string email)
    {
        return Users.SingleOrDefault(u => u.Email == email);
    }

    public void Add(User user)
    {
        Users.Add(user);
    }
}
namespace BuberDinner.Domain.Users;

using Common;

using ValueObjects;

public sealed class User : AggregateRoot<UserId, Guid>, ITrackable
{
#pragma warning disable CS8618
    private User()
    {
    }
#pragma warning restore CS8618

    private User(
        UserId id,
        string firstName,
        string lastName,
        string email,
        string password,
        DateTime createdOn,
        DateTime modifiedOn)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }
    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }

    public static User SpawnOne(
        string firstName,
        string lastName,
        string email,
        string password,
        DateTime createdOn,
        DateTime modifiedOn)
    {
        return new User(
            UserId.SpawnUniqueOne(),
            firstName,
            lastName,
            email,
            password,
            createdOn,
            modifiedOn);
    }
}
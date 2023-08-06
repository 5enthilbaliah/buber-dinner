namespace BuberDinner.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            "User.DuplicateEmail",
            "Email id is already taken");
    }
}
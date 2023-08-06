namespace BuberDinner.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            "Auth.InvalidCredentials",
            "Invalid credentials");

        public static Error EmailNotFound => Error.NotFound(
            "Auth.EmailNotFound",
            "Email not found");
    }
}
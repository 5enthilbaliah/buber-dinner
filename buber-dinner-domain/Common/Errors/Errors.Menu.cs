namespace BuberDinner.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class Menu
    {
        public static Error InvalidHost => Error.Validation(
            code: "Menu.InvalidHost",
            description: "Invalid host: host id should be of guid format");
    }
}
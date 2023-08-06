namespace BuberDinner.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class Menu
    {
        public static Error InvalidHost => Error.Validation(
            code: "Menu.InvalidHost",
            description: "Invalid host: host id should be of guid format");
        
        public static Error InvalidMenu => Error.Validation(
            code: "Menu.InvalidMenu",
            description: "Invalid menu: menu id should be of guid format");
        
        public static Error MenuNotFound => Error.NotFound(
            code: "Menu.MenuNotFound",
            description: "Menu not found: the menu you are looking is not found in our system.");
    }
}
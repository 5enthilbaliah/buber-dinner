namespace BuberDinner.Application.Menus.Commands.CreateMenu;

using FluentValidation;

public class CreateMenuCommandValidator: AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(x => x.HostId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Sections).NotEmpty();
    }
}
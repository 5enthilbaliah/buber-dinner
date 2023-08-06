namespace BuberDinner.Host.Installers;

using Application;
using Application.Common.Behaviors;

using Enums;

using FluentValidation;

using Interfaces;

using MediatR;

public class MediatorServiceInstaller : IServiceInstaller
{
    public InstallationOrder Order => InstallationOrder.Mediator;

    public void Install(IServiceCollection services, IConfiguration configuration, string environment)
    {
        services.AddValidatorsFromAssembly(typeof(ApplicationModule).Assembly);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ApplicationModule).Assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });
    }
}
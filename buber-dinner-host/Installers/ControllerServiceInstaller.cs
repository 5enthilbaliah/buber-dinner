namespace BuberDinner.Host.Installers;

using Enums;

using Interfaces;

using Presentation;

public class ControllerServiceInstaller : IServiceInstaller
{
    public InstallationOrder Order => InstallationOrder.Controllers;

    public void Install(IServiceCollection services, IConfiguration configuration, string environment)
    {
        /*services.AddControllers(options => options.Filters.Add<ErrorHandlingFilter>())
            .AddApplicationPart(typeof(PresentationModule).Assembly);*/

        services.AddControllers()
            .AddApplicationPart(typeof(PresentationModule).Assembly);

        services.AddHttpContextAccessor();
    }
}
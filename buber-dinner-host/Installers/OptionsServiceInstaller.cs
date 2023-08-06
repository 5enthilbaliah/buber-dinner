namespace BuberDinner.Host.Installers;

using Enums;

using Infrastructure.Authentication;

using Interfaces;

public class OptionsServiceInstaller : IServiceInstaller
{
    public InstallationOrder Order => InstallationOrder.Options;

    public void Install(IServiceCollection services, IConfiguration configuration, string environment)
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
    }
}
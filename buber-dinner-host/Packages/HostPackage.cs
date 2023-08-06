namespace BuberDinner.Host.Packages;

using Application;

using Autofac;

using Infrastructure;

using Interfaces;

using Mapster;

using MapsterMapper;

using Presentation;

public class HostPackage : IPackage
{
    public void Register(ContainerBuilder container, IConfiguration configuration, string environment)
    {
        container.RegisterModule<ApplicationModule>();
        container.RegisterModule<InfrastructureModule>();
        container.RegisterModule<PresentationModule>();
        
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(PresentationModule).Assembly);
        config.Scan(typeof(ApplicationModule).Assembly);

        container.RegisterInstance(config).SingleInstance();
        container.RegisterType<ServiceMapper>().As<IMapper>()
            .SingleInstance();
    }
}
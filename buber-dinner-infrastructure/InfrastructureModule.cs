namespace BuberDinner.Infrastructure;

using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;

using Authentication;

using Autofac;

using Persistence;

using Services;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<JwtTokenGenerator>().As<IJwtTokenGenerator>()
            .SingleInstance();

        builder.RegisterType<DateTimeProvider>().As<IDateTimeProvider>()
            .SingleInstance();

        builder.RegisterType<UserRepository>().As<IUserRepository>()
            .InstancePerLifetimeScope();
        builder.RegisterType<MenuRepository>().As<IMenuRepository>()
            .InstancePerLifetimeScope();
    }
}
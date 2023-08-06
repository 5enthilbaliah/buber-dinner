namespace BuberDinner.Infrastructure;

using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;

using Authentication;

using Autofac;

using Microsoft.EntityFrameworkCore;

using Persistence;
using Persistence.Repositories;

using Services;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<JwtTokenGenerator>().As<IJwtTokenGenerator>()
            .SingleInstance();

        builder.RegisterType<DateTimeProvider>().As<IDateTimeProvider>()
            .SingleInstance();

        builder.Register(context =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<BuberDinnerDbContext>();
            optionsBuilder.UseSqlServer("");
            return new BuberDinnerDbContext(optionsBuilder.Options);
        }).InstancePerLifetimeScope();

        builder.RegisterType<UserRepository>().As<IUserRepository>()
            .InstancePerLifetimeScope();
        builder.RegisterType<MenuRepository>().As<IMenuRepository>()
            .InstancePerLifetimeScope();
    }
}
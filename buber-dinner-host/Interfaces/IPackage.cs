namespace BuberDinner.Host.Interfaces;

using Autofac;

public interface IPackage
{
    void Register(ContainerBuilder container, IConfiguration configuration, string environment);
}
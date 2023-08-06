using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using BuberDinner.Host;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", 
        false, true)
    .AddUserSecrets(Assembly.GetExecutingAssembly());

builder.Services.InstallServices(builder.Configuration, builder.Environment);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.RegisterPackages(builder.Configuration, builder.Environment);

var app = builder.Build();
app.ChainPipelines(builder.Configuration, builder.Environment);
app.Run();
namespace BuberDinner.Presentation;

using Autofac;

using Common.Errors;

using Microsoft.AspNetCore.Mvc.Infrastructure;

public class PresentationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<BuberDinnerProblemDetailsFactory>().As<ProblemDetailsFactory>()
            .SingleInstance();
    }
}
namespace BuberDinner.Host.Pipelines;

using Enums;

using Interfaces;

public class ControllerPipeline : IMiddlewarePipeline
{
    public PipelineOrder Step => PipelineOrder.Controllers;

    public void Pipe(IApplicationBuilder app, IConfiguration configuration, string environment)
    {
        (app as WebApplication)!.MapControllers();
    }
}
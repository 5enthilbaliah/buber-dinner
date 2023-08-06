namespace BuberDinner.Host.Pipelines;

using Enums;

using Interfaces;

public class HttpsRedirectionPipeline : IMiddlewarePipeline
{
    public PipelineOrder Step => PipelineOrder.Https;

    public void Pipe(IApplicationBuilder app, IConfiguration configuration, string environment)
    {
        app.UseHttpsRedirection();
    }
}
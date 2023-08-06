namespace BuberDinner.Host.Pipelines;

using Enums;

using Interfaces;

public class AuthenticationPipeline : IMiddlewarePipeline
{
    public PipelineOrder Step => PipelineOrder.Authentication;

    public void Pipe(IApplicationBuilder app, IConfiguration configuration, string environment)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}
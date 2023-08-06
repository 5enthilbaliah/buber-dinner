namespace BuberDinner.Host.Pipelines;

using Enums;

using Interfaces;

using Middlewares;

public class ExceptionHandlePipeline : IMiddlewarePipeline
{
    public PipelineOrder Step => PipelineOrder.Exceptions;

    public void Pipe(IApplicationBuilder app, IConfiguration configuration, string environment)
    {
        app.UseMiddleware<ErrorHandlingMiddleware>();
    }
}
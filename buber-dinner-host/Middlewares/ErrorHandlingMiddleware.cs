namespace BuberDinner.Host.Middlewares;

using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

using Presentation.Common.Http;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ProblemDetailsFactory? _problemDetailsFactory;

    public ErrorHandlingMiddleware(RequestDelegate next, ProblemDetailsFactory? problemDetailsFactory)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _problemDetailsFactory = problemDetailsFactory;
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = (int)HttpStatusCode.InternalServerError; // 500 if excepted
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = code;
        var title = "Unexpected error";
        var errorMsg = "Well, this is embarrassing... It appears something has gone awry. " +
                       "Please report this incident to the tech team for further investigation.";

        ProblemDetails problemDetails;
        if (_problemDetailsFactory is not null)
        {
            problemDetails = _problemDetailsFactory.CreateProblemDetails(
                context,
                code,
                title,
                detail: errorMsg);
        }
        else
        {
            problemDetails = new ProblemDetails { Detail = errorMsg, Status = code, Title = title };
        }

        return context.Response.WriteAsJsonAsync(problemDetails);
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Items.Remove(HttpContextItemKeys.Errors);
            await HandleExceptionAsync(context, ex);
        }
    }
}
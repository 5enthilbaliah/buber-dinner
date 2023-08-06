namespace BuberDinner.Presentation.Filters;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

public class ErrorHandlingFilter : IExceptionFilter
{
    private readonly ProblemDetailsFactory _problemDetailsFactory;

    public ErrorHandlingFilter(ProblemDetailsFactory problemDetailsFactory)
    {
        _problemDetailsFactory =
            problemDetailsFactory ?? throw new ArgumentNullException(nameof(problemDetailsFactory));
    }

    public void OnException(ExceptionContext context)
    {
        // https://datatracker.ietf.org/doc/html/rfc7807
        var exception = context.Exception;
        var httpContext = context.HttpContext;

        var problemDetails = _problemDetailsFactory.CreateProblemDetails(httpContext,
            StatusCodes.Status500InternalServerError,
            "Ah snap!!! It appears something has gone awry. " +
            "Please report this incident to the tech team for further investigation.");

        context.Result = new ObjectResult(problemDetails) { StatusCode = problemDetails.Status };

        context.ExceptionHandled = true;
    }
}
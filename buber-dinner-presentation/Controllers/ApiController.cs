namespace BuberDinner.Presentation.Controllers;

using Common.Http;

using ErrorOr;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

[ApiController]
public class ApiController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApiController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();
        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(
                error.Code,
                error.Description);
        }

        return ValidationProblem(modelStateDictionary);
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        if (error.Code == "Auth.InvalidCredentials")
        {
            statusCode = StatusCodes.Status401Unauthorized;
        }

        return Problem(statusCode: statusCode, title: error.Description);
    }

    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.All(e => e.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);
        }

        if (_httpContextAccessor.HttpContext is not null)
        {
            _httpContextAccessor.HttpContext.Items[HttpContextItemKeys.Errors] = errors;
        }

        var firstError = errors[0];

        return Problem(firstError);
    }
}
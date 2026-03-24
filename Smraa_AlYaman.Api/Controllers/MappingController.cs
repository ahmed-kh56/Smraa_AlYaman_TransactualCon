using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Api.Controllers;

[ApiController]
public class MappingController : ControllerBase
{

    protected IActionResult Success(DoneStatus status)
    {
        return status switch
        {
            DoneStatus.Done => Ok(),
            DoneStatus.Created => Created(string.Empty, null),
            DoneStatus.Accepted => Accepted(),
            DoneStatus.Partial => StatusCode(StatusCodes.Status206PartialContent),
            DoneStatus.NoContent => NoContent(),
            _ => Ok()
        };
    }


    protected IActionResult Success<T>(
        T value,
        DoneStatus status,
        object? routeValues = null,
        string getMethod = "GetById")
    {
        return status switch
        {
            DoneStatus.Created => StatusCode(201, value),
            DoneStatus.Done => Ok(value),
            DoneStatus.Accepted => Accepted(value),
            DoneStatus.Partial => StatusCode(206, value),
            DoneStatus.NoContent => NoContent(),

            _ => Ok(value)
        };
    }


    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0)
        {
            return Problem();
        }

        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);
        }

        return Problem(errors[0]);
    }

    protected IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Unauthorized => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status500InternalServerError,
        };

        return Problem(statusCode: statusCode, detail: error.Description);
    }

    protected IActionResult ValidationProblem(List<Error> errors)
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

    protected IActionResult MapResult<T>(ResultOf<T> result)
    {
        return result.Match(
            (value, status) => Success(value, status),
            errors => Problem(errors)
        );
    }




}

using FluentResults;
using phoenix_web_bff.Presentation.Common.ResultUtils.Errors;

namespace phoenix_web_bff.Presentation.Common.ResultUtils.Extensions;

public static class ResultConvertingExtensions
{
    public static IResult ToActionResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
            return Results.Ok(result.Value);

        return MapFailure(result.Errors);
    }
    
    public static IResult ToActionResult(this Result result)
    {
        if (result.IsSuccess)
            return Results.NoContent();

        return MapFailure(result.Errors);
    }

    private static IResult MapFailure(IEnumerable<IError> errors)
    {
        var error = errors.FirstOrDefault();

        return error switch
        {
            null => Results.BadRequest(new {error = "Unknown error occured..."}),
            
            ConflictError => Results.Conflict(new { error = error.Message }),
            ForbiddenError => Results.Forbid(),
            UnauthorizedError => Results.Unauthorized(),
            NotFoundError => Results.NotFound(new { error = error.Message }),
            ValidationError => Results.BadRequest(new { error = error.Message }),

            ServiceUnavailableError => Results.Json(new { error = error.Message }, 
                statusCode: StatusCodes.Status503ServiceUnavailable),
            TimeoutError => Results.Json(new { error = error.Message }, 
                statusCode: StatusCodes.Status504GatewayTimeout),
            InternalError => Results.Json(new { error = error.Message }, 
                statusCode: StatusCodes.Status500InternalServerError),
            GrpcError => Results.Json(new { error = error.Message }, 
                statusCode: StatusCodes.Status502BadGateway),
            UnknownError => Results.Json(new { error = error.Message }, 
                statusCode: StatusCodes.Status500InternalServerError),
            
            Error => Results.Json(new { error = error.Message }, 
                statusCode: StatusCodes.Status500InternalServerError),
            IExceptionalError => Results.Json(new { error = error.Message }, 
                statusCode: StatusCodes.Status500InternalServerError),
            
            _ => Results.Json(new { error = "An unexpected error occurred." }, 
                statusCode: StatusCodes.Status500InternalServerError)
        };
    }
}
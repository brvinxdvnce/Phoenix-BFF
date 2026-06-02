namespace phoenix_web_bff.Presentation.Middleware;

public class ExceptionHandleMiddleware(RequestDelegate next, ILogger<ExceptionHandleMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        logger.LogError(exception, exception.Message);
        
        var (statusCode, message) = exception switch
        {
            Exception => (StatusCodes.Status500InternalServerError, exception.Message),
            
            _ => (StatusCodes.Status500InternalServerError, exception.Message),
        };
        
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(new {error = message});
    }
}
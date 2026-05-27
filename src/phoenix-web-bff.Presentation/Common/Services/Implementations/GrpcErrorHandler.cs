using FluentResults;
using Grpc.Core;
using phoenix_web_bff.Presentation.Common.ResultUtils.Errors;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;

namespace phoenix_web_bff.Presentation.Common.Services.Implementations;

public class GrpcErrorHandler(ILogger<GrpcErrorHandler> logger) : IGrpcErrorHandler
{
    public async Task<Result<T>> TryAsync<T>(Func<Task<T>> call)
    {
        try
        {
            var response = await call();
            return Result.Ok(response);
        }
        catch (RpcException ex)
        {
            LogError(ex);
            return Result.Fail(BindResponseError(ex));
        }
    } 
    
    public async Task<Result> TryAsync(Func<Task> call)
    {
        try
        {
            await call();
            return Result.Ok();
        }
        catch (RpcException ex) {
            return Result.Fail(BindResponseError(ex));
        }
    }
 
    private static Error BindResponseError(RpcException ex)
    {
        return ex.StatusCode switch
        {
            StatusCode.InvalidArgument  => new ValidationError(ex.Status.Detail ?? ex.Message),
            StatusCode.AlreadyExists    => new ConflictError(ex.Status.Detail ?? ex.Message),
            StatusCode.PermissionDenied => new ForbiddenError(ex.Status.Detail ?? ex.Message),
            StatusCode.Unauthenticated  => new UnauthorizedError(ex.Status.Detail ?? ex.Message),
            StatusCode.DeadlineExceeded => new TimeoutError(ex.Status.Detail ?? ex.Message),
            StatusCode.Unavailable      => new ServiceUnavailableError(ex.Status.Detail ?? ex.Message),
            StatusCode.Internal         => new InternalError(ex.Status.Detail ?? ex.Message),
            StatusCode.Unknown          => new UnknownError(ex.Status.Detail ?? ex.Message),
            _                           => new GrpcError($"gRPC error [{ex.StatusCode}]: {ex.Status.Detail ?? ex.Message}")
        };
    }
    
    
    private void LogError(RpcException ex)
    {
        var logLevel = ex.StatusCode switch
        {
            // Критические ошибки
            StatusCode.Internal or
                StatusCode.Unknown or
                StatusCode.Unavailable or
                StatusCode.DataLoss or
                StatusCode.DeadlineExceeded => LogLevel.Error,

            // Ошибки бизнес-логики
            StatusCode.InvalidArgument or
                StatusCode.NotFound or
                StatusCode.AlreadyExists or
                StatusCode.PermissionDenied or
                StatusCode.Cancelled or    
                StatusCode.Unauthenticated => LogLevel.Debug,

            _ => LogLevel.Information
        };

        logger.Log(logLevel, ex, "gRPC call failed: StatusCode={StatusCode}, Message={Message}",
            ex.StatusCode, ex.Message);
    }
}
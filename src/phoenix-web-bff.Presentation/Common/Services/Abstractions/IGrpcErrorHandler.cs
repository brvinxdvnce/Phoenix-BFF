using FluentResults;

namespace phoenix_web_bff.Presentation.Common.Services.Abstractions;

public interface IGrpcErrorHandler
{
    public Task<Result<T>> TryAsync<T>(Func<Task<T>> call);
    public Task<Result> TryAsync(Func<Task> call);
}
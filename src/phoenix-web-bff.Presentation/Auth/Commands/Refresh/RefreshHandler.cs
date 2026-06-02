using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Auth.Commands.Refresh;

public class RefreshHandler (
    IGrpcErrorHandler errorHandler,
    AuthService.AuthServiceClient authServiceClient
    ) : IRequestHandler<RefreshCommand, Result<AuthResponse>>
{
    public async Task<Result<AuthResponse>> Handle(RefreshCommand request, CancellationToken ct)
    {
        return await errorHandler.TryAsync(() =>
            authServiceClient
                .RefreshAsync(
                    request.Request,
                    new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}
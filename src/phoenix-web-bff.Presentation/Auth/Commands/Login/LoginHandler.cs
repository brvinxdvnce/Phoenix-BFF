using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Auth.Commands.Login;

public class LoginHandler(
    IGrpcErrorHandler errorHandler,
    AuthService.AuthServiceClient authServiceClient
    ) : IRequestHandler<LoginCommand, Result<AuthResponse>>
{
    public async Task<Result<AuthResponse>> Handle(LoginCommand request, CancellationToken ct)
    {
        return await errorHandler.TryAsync(() =>
            authServiceClient
                .LoginAsync(
                    request.Request,
                    new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}
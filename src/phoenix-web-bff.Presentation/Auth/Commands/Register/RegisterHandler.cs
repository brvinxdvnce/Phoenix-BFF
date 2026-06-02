using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Auth.Commands.Register;

public class RegisterHandler (
    IGrpcErrorHandler errorHandler,
    AuthService.AuthServiceClient authServiceClient
    ) : IRequestHandler<RegisterCommand, Result<AuthResponse>>
{
    public async Task<Result<AuthResponse>> Handle(RegisterCommand request, CancellationToken ct)
    {
        return await errorHandler.TryAsync(() =>
            authServiceClient
                .RegisterAsync(
                    request.Request, 
                    new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}
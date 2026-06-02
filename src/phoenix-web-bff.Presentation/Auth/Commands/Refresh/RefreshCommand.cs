using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Auth.Commands.Refresh;

public record RefreshCommand(RefreshRequest Request) : IRequest<Result<AuthResponse>>;
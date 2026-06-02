using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Auth.Commands.Login;

public record LoginCommand(LoginRequest Request) : IRequest<Result<AuthResponse>>; 
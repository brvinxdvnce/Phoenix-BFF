using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Auth.Commands.Register;

public record RegisterCommand(RegistrationRequest Request) 
    : IRequest<Result<AuthResponse>>;
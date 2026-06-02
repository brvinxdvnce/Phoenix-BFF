using MediatR;
using Microsoft.AspNetCore.Mvc;
using phoenix_web_bff.Presentation.Auth.Commands.Login;
using phoenix_web_bff.Presentation.Auth.Commands.Refresh;
using phoenix_web_bff.Presentation.Auth.Commands.Register;
using phoenix_web_bff.Presentation.Common.ResultUtils.Extensions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Endpoints;

public static class AuthEndpoints
{
    public static WebApplication AddAuthEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/v1/auth");

        group.MapPost("/login", async (
                [FromBody] LoginRequest request,
                [FromServices] IMediator mediator,
                CancellationToken ct) => 
                (await mediator.Send(new LoginCommand(request), ct)).ToActionResult())
            .WithName("Login");
        
        group.MapPost("/refresh", async (
                [FromBody] RefreshRequest refreshRequest,
                [FromServices] IMediator mediator,
                CancellationToken ct) => 
                (await mediator.Send(new RefreshCommand(refreshRequest), ct)).ToActionResult())
            .WithName("Refresh");
        
        group.MapPost("/register", async (
                [FromBody] RegistrationRequest registrationRequest,
                [FromServices] IMediator mediator,
                CancellationToken ct) => 
                (await mediator.Send(new RegisterCommand(registrationRequest), ct)).ToActionResult())
            .WithName("Register");
        
        return app;
    }
}
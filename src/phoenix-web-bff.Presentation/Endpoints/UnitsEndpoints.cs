using MediatR;
using Microsoft.AspNetCore.Mvc;
using phoenix_web_bff.Presentation.Common.ResultUtils.Extensions;
using phoenix_web_bff.Presentation.Units.Commands.CreateUnit;
using phoenix_web_bff.Presentation.Units.Commands.DeleteUnit;
using phoenix_web_bff.Presentation.Units.Queries.GetUnit;
using Phoenix;

namespace phoenix_web_bff.Presentation.Endpoints;

public static class UnitsEndpoints
{
    public static WebApplication AddUnitsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/v1/units");
        
        group.MapPost("/",  async (
                    [FromBody] CreateUnitCommand command,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) => 
                (await mediator.Send(command, ct)).ToActionResult())
            .WithName("Добавить юнит");

        group.MapGet("/{id}",  async (
                    [FromRoute] string id,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) => 
                (await mediator.Send(new GetUnitQuery(id), ct)).ToActionResult())
            .WithName("Получить юнит");
        
        group.MapDelete("/{id}",  async (
                    [FromRoute] string id,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) => 
                (await mediator.Send(new DeleteUnitCommand(id), ct)).ToActionResult())
            .WithName("Удалить юнит");

        return app;
    }
}
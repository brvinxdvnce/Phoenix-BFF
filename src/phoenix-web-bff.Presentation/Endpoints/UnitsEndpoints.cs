using MediatR;
using Microsoft.AspNetCore.Mvc;
using phoenix_web_bff.Presentation.Common.ResultUtils.Extensions;
using phoenix_web_bff.Presentation.Units.Commands.AddMetricToUnit;
using phoenix_web_bff.Presentation.Units.Commands.AddTeamToUnit;
using phoenix_web_bff.Presentation.Units.Commands.CreateUnit;
using phoenix_web_bff.Presentation.Units.Commands.DeleteUnit;
using phoenix_web_bff.Presentation.Units.Commands.UpdateUnit;
using phoenix_web_bff.Presentation.Units.Dto;
using phoenix_web_bff.Presentation.Units.Queries.GetUnit;
using phoenix_web_bff.Presentation.Units.Queries.GetUnits;
using Phoenix;

namespace phoenix_web_bff.Presentation.Endpoints;

public static class UnitsEndpoints
{
    public static WebApplication AddUnitsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/v1/units");

        group.MapGet("/", async (
                    [FromServices] IMediator mediator,
                    CancellationToken ct) =>
                (await mediator.Send(new GetUnitsQuery(), ct)).ToActionResult())
            .WithName("Get units");
        
        group.MapPost("/",  async (
                    [FromBody] CreateUnitCommand command,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) => 
                (await mediator.Send(command, ct)).ToActionResult())
            .WithName("Add unit");

        group.MapGet("/{unitId}",  async (
                    [FromRoute] string unitId,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) => 
                (await mediator.Send(new GetUnitQuery(unitId), ct)).ToActionResult())
            .WithName("Get unit by Id");

        group.MapPatch("/{unitId}", async (
                    [FromRoute] string unitId,
                    [FromServices] IMediator mediator,
                    [FromBody] UpdateUnitDto updateDto,
                    CancellationToken ct) =>
                (await mediator.Send(new UpdateUnitCommand(unitId, updateDto), ct)).ToActionResult())
            .WithName("Update unit");
        
        group.MapDelete("/{unitId}",  async (
                    [FromRoute] string unitId,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) => 
                (await mediator.Send(new DeleteUnitCommand(unitId), ct)).ToActionResult())
            .WithName("Delete unit");

        group.MapPost("/{unitId}/teams", async (
                    [FromRoute] string unitId,
                    [FromQuery] string teamId,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) => 
                (await mediator.Send(new AddTeamToUnitCommand(unitId,  teamId), ct)).ToActionResult())
            .WithName("Add team to unit");
        
        group.MapPost("{unitId}/metrics", async (
                    [FromRoute] string unitId,
                    [FromBody] AddMetricToUnitDto metricToUnitDto,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) => 
                (await mediator.Send(new AddMetricToUnitCommand(unitId, metricToUnitDto), ct)).ToActionResult())
            .WithName("Add metric to unit");
        
        return app;
    }
}
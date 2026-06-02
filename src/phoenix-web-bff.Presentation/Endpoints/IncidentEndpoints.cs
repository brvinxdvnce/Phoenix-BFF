using MediatR;
using Microsoft.AspNetCore.Mvc;
using phoenix_web_bff.Presentation.Common.ResultUtils.Extensions;
using phoenix_web_bff.Presentation.Incidents.Commands.CreateIncident;
using phoenix_web_bff.Presentation.Incidents.Commands.CreateIncidentGroupGroup;
using phoenix_web_bff.Presentation.Incidents.Queries.GetIncident;
using phoenix_web_bff.Presentation.Incidents.Queries.GetIncidents;
using Phoenix;

namespace phoenix_web_bff.Presentation.Endpoints;

public static class IncidentEndpoints
{
    public static WebApplication AddIncidentEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/v1/incidents");

        group.MapPost("/", async (
                    [FromBody] CreateIncidentCommand cmd,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) =>
                (await mediator.Send(cmd, ct)).ToActionResult())
            .WithName("Add incident");

        group.MapGet("/", async (
                    [FromServices] IMediator mediator,
                    CancellationToken ct) =>
                (await mediator.Send(new GetIncidentsQuery(), ct)).ToActionResult())
            .WithName("Get incidents");

        group.MapGet("/{incidentId}", async (
                    [FromRoute] string incidentId,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) =>
                (await mediator.Send(new GetIncidentQuery(incidentId), ct)).ToActionResult())
            .WithName("Get incident by Id");

        group.MapPost("/groups", async (
                    [FromBody] CreateIncidentGroupRequest request,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) =>
                (await mediator.Send(new CreateIncidentGroupCommand(request), ct)).ToActionResult())
            .WithName("Create incident group");
            
    return app;
    }
}
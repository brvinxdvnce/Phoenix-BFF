using MediatR;
using Microsoft.AspNetCore.Mvc;
using phoenix_web_bff.Presentation.Common.ResultUtils.Extensions;
using phoenix_web_bff.Presentation.Incidents.Commands.CreateIncident;
using phoenix_web_bff.Presentation.Incidents.Queries.GetIncident;
using phoenix_web_bff.Presentation.Incidents.Queries.GetIncidents;

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
            .WithName("Создать инцидент");
        
        group.MapGet ("/", async (
                    [FromServices] IMediator mediator,
                    CancellationToken ct) => 
                (await mediator.Send(new GetIncidentsQuery(), ct)).ToActionResult())
            .WithName("Просмотреть инциденты");
        
        group.MapGet ("/{incidentId}", async (
                    [FromRoute] string incidentId,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) => 
                (await mediator.Send(new GetIncidentQuery(incidentId), ct)).ToActionResult())
            .WithName("Просмотреть один инцидент");
        
        return app;
    }
}
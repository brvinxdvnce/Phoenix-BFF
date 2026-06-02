using MediatR;
using Microsoft.AspNetCore.Mvc;
using phoenix_web_bff.Presentation.Common.ResultUtils.Extensions;
using phoenix_web_bff.Presentation.Incidents.Commands.CreateIncident;
using phoenix_web_bff.Presentation.IncidentSeverities.Commands.CreateIncidentSeverity;
using phoenix_web_bff.Presentation.IncidentSeverities.Commands.RemoveIncidentSeverity;
using phoenix_web_bff.Presentation.IncidentSeverities.Commands.UpdateSeverity;
using phoenix_web_bff.Presentation.IncidentSeverities.Queries.GetAllIncidentSeverities;
using Phoenix;

namespace phoenix_web_bff.Presentation.Endpoints;

public static class IncidentSeverityEndpoints
{
    public static WebApplication AddIncidentSeverityEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/v1/incidents/");
        
        // probably wrong! maybe there should be Id in the route
        group.MapPost("/severities", async (
                    [FromBody] CreateIncidentSeverityMessage message,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) =>
                (await mediator.Send(new CreateIncidentSeverityCommand(message), ct)).ToActionResult())
            .WithName("Add incident severity");
        
        group.MapGet("/severities", async(
                    [FromServices] IMediator mediator,
                    CancellationToken ct) => 
                (await mediator.Send(new GetAllIncidentSeveritiesQuery(), ct)).ToActionResult())
            .WithName("Get incident severities");
        
        group.MapDelete("/{incidentId}/severity", async (
                    [FromRoute] string incidentId,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) =>
                (await mediator.Send(new RemoveIncidentSeverityCommand(new Id {Id_ = incidentId}), ct)).ToActionResult())
            .WithName("Delete incident severity by Id");
        
        group.MapPatch("/{incidentId}/severity", async (
                    [FromRoute] string incidentId,
                    [FromQuery] double coefficient,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) =>
                (await mediator.Send(
                    new UpdateSeverityCommand(
                        new UpdateIncidentSeverityCoefficientRequest()
                        {
                            Id = new Id {Id_ = incidentId},
                            Value = coefficient
                        }), ct)).ToActionResult())
            .WithName("Update incident severity by Id");

        
        return app;
    }
}
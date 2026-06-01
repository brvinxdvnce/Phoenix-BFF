using MediatR;
using Microsoft.AspNetCore.Mvc;
using phoenix_web_bff.Presentation.Common.ResultUtils.Extensions;
using phoenix_web_bff.Presentation.Incidents.Queries.GetIncidents;
using phoenix_web_bff.Presentation.Metrics.Commands.AddMetric;
using phoenix_web_bff.Presentation.Metrics.Queries.GetMetric;
using phoenix_web_bff.Presentation.Metrics.Queries.GetMetrics;
using phoenix_web_bff.Presentation.Metrics.Queries.GetMetricValue;
using phoenix_web_bff.Presentation.Metrics.Queries.GetRawMetricValue;
using Phoenix;

namespace phoenix_web_bff.Presentation.Endpoints;

public static class MetricsEndpoints
{
    public static WebApplication AddMetricsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/v1/metrics");
        
        group.MapPost("/", async (
                    [FromServices] IMediator mediator,
                    [FromBody] AddMetricCommand cmd,
                    CancellationToken ct) => 
                (await mediator.Send(cmd, ct)).ToActionResult())
            .WithName("Add metric");
        
        group.MapGet("/", async (
                    [FromServices] IMediator mediator,
                    CancellationToken ct) => 
                (await mediator.Send(new GetMetricsQuery(), ct)).ToActionResult())
            .WithName("Get metrics");

        group.MapGet("/{metricId}", async (
                    [FromRoute] string metricId,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) => 
                (await mediator.Send(new GetMetricQuery(metricId), ct)).ToActionResult())
            .WithName("Get metric by Id");

        group.MapGet("{metricId}/value", async (
                    [FromRoute] string metricId,
                    [FromQuery] int unixTime,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) =>
                (await mediator.Send(
                    new GetMetricValueQuery(
                        new GetMetricValueRequest 
                            {
                                Id = metricId,
                                UnixTime = unixTime
                                
                            }), ct))
                .ToActionResult())
            .WithName("Get metric value by Id");
        
        group.MapGet("/value/raw", async (
                    [FromQuery] string query,
                    [FromQuery] int unixTime,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) =>
                (await mediator.Send(
                    new GetRawMetricValueQuery(
                        new GetRawMetricValueRequest 
                        {
                            Query = query,
                            UnixTime = unixTime
                        }), ct)).ToActionResult())
            .WithName("Get raw metric value");
        
        return app;
    }
}
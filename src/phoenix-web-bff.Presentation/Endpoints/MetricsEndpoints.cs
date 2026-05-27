using MediatR;
using Microsoft.AspNetCore.Mvc;
using phoenix_web_bff.Presentation.Common.ResultUtils.Extensions;
using phoenix_web_bff.Presentation.Incidents.Queries.GetIncidents;
using phoenix_web_bff.Presentation.Metrics.Commands.AddMetric;
using phoenix_web_bff.Presentation.Metrics.Queries.GetMetric;
using phoenix_web_bff.Presentation.Metrics.Queries.GetMetrics;

namespace phoenix_web_bff.Presentation.Endpoints;

public static class MetricsEndpoints
{
    public static WebApplication AddMetricsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/metrics");
        
        group.MapPost("/", async (
                    [FromServices] IMediator mediator,
                    [FromBody] AddMetricCommand cmd,
                    CancellationToken ct) => 
                (await mediator.Send(cmd, ct)).ToActionResult())
            .WithName("Добавить метрику");
        
        group.MapGet("/", async (
                    [FromServices] IMediator mediator,
                    CancellationToken ct) => 
                (await mediator.Send(new GetMetricsQuery(), ct)).ToActionResult())
            .WithName("Получить метрики");

        group.MapGet("/{metricId}", async (
                    [FromRoute] string metricId,
                    [FromServices] IMediator mediator,
                    CancellationToken ct) => 
                (await mediator.Send(new GetMetricQuery(metricId), ct)).ToActionResult())
            .WithName("Получить одну метрику");
        
        return app;
    }
}
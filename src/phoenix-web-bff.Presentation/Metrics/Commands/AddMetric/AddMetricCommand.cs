using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Metrics.Commands.AddMetric;

public record AddMetricCommand(
    string Severity,
    string Title,
    string Description,
    string Query,
    double Threshold,
    int ThresholdDirection,
    string? RunbookLinkTemplate,
    string? MonitoringLinkTemplate) : IRequest<Result<MetricResponse>>;

using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Metrics.Queries.GetMetric;

public record GetMetricQuery(string MetricId) : IRequest<Result<MetricResponse>>;
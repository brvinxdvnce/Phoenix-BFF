using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Metrics.Queries.GetRawMetricValue;

public record GetRawMetricValueQuery(GetRawMetricValueRequest Request)
    : IRequest<Result<MetricValueResponse>>;
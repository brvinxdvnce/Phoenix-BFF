using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Metrics.Queries.GetMetricValue;

public record GetMetricValueQuery(GetMetricValueRequest Request) 
    : IRequest<Result<MetricValueResponse>>;
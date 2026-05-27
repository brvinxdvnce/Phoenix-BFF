using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Metrics.Queries.GetMetrics;

public class GetMetricsQuery() : IRequest<Result<MetricListResponse>>;
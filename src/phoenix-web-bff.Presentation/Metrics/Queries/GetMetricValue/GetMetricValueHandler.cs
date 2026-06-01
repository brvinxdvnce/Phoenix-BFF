using FluentResults;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Metrics.Queries.GetMetricValue;

public class GetMetricValueHandler(
    IGrpcErrorHandler errorHandler, 
    MetricService.MetricServiceClient metricServiceClient
    ) : IRequestHandler<GetMetricValueQuery, Result<MetricValueResponse>>
{
    public async Task<Result<MetricValueResponse>> Handle(GetMetricValueQuery request, CancellationToken cancellationToken)
    {
        return await errorHandler.TryAsync(() => 
            metricServiceClient
                .GetMetricValueAsync(request.Request)
                .ResponseAsync);
    }
}
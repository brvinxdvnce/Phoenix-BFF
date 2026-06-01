using FluentResults;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Metrics.Queries.GetRawMetricValue;

public class GetRawMetricValueHandler(
    IGrpcErrorHandler errorHandler, 
    MetricService.MetricServiceClient metricServiceClient
    ) : IRequestHandler<GetRawMetricValueQuery, Result<MetricValueResponse>>
{
    public async Task<Result<MetricValueResponse>> Handle(GetRawMetricValueQuery request, CancellationToken cancellationToken)
    {
        return await errorHandler.TryAsync(() => 
            metricServiceClient
                .GetRawMetricValueAsync(request.Request)
                .ResponseAsync);
    }
}
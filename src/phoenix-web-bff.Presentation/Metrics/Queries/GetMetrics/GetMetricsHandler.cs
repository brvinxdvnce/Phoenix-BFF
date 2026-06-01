using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Metrics.Queries.GetMetrics;

public class GetMetricsHandler(
    IGrpcErrorHandler grpcErrorHandler,
    MetricService.MetricServiceClient metricServiceClient
    ) : IRequestHandler<GetMetricsQuery, Result<MetricListResponse>>
{
    public async Task<Result<MetricListResponse>> Handle(GetMetricsQuery request, CancellationToken ct)
    {
        return await grpcErrorHandler.TryAsync(() =>
            metricServiceClient
                .GetMetricsAsync(
                    new Empty(),
                    new CallOptions(cancellationToken: ct)
                ).ResponseAsync);
    }
}
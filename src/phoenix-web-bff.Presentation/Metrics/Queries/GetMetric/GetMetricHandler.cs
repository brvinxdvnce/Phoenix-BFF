using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Metrics.Queries.GetMetric;

public class GetMetricHandler(
    IGrpcErrorHandler grpcErrorHandler,
    MetricService.MetricServiceClient metricServiceClient
    ) : IRequestHandler<GetMetricQuery, Result<MetricResponse>>
{
    public async Task<Result<MetricResponse>> Handle(GetMetricQuery request, CancellationToken ct)
    {
        return await grpcErrorHandler.TryAsync(() =>
            metricServiceClient
                .GetMetricAsync(
                    new Id { Id_ = request.MetricId },
                    new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}
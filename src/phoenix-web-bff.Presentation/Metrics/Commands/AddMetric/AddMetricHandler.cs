using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Metrics.Commands.AddMetric;

public class AddMetricHandler(
    IGrpcErrorHandler grpcErrorHandler, 
    MetricService.MetricServiceClient metricServiceClient
    ) : IRequestHandler<AddMetricCommand, Result<MetricResponse>>
{
    public async Task<Result<MetricResponse>> Handle(AddMetricCommand command, CancellationToken ct)
    {
        var metricRequest = new AddMetricRequest
        {
            Severity = command.Severity,
            Title = command.Title,
            Description = command.Description,
            Query = command.Query,
            Threshold = command.Threshold,
            ThresholdDirection = (ThresholdDirection) command.ThresholdDirection,
            RunbookLinkTemplate = command.RunbookLinkTemplate ?? "",
            MonitoringLinkTemplate = command.MonitoringLinkTemplate ?? ""
        };
        
        return await grpcErrorHandler.TryAsync(() =>
            metricServiceClient
                .AddMetricAsync(
                    metricRequest,
                    new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}

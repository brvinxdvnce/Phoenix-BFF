using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Units.Commands.AddMetricToUnit;

public class AddMetricToUnitHandler(
    IGrpcErrorHandler grpcErrorHandler,
    UnitService.UnitServiceClient unitServiceClient
    ) : IRequestHandler<AddMetricToUnitCommand, Result<Empty>>
{
    public async Task<Result<Empty>> Handle(AddMetricToUnitCommand request, CancellationToken cancellationToken)
    {
        return await grpcErrorHandler.TryAsync(() =>
            unitServiceClient.AddMetricToUnitAsync(
                new AddMetricToUnitRequest()
                {
                    UnitId = request.UnitId, 
                    MetricId = request.MetricToUnitDto.MetricId,
                    InfluenceLevel = request.MetricToUnitDto.InfluenceLevel
                },
                new CallOptions(cancellationToken: cancellationToken))
                .ResponseAsync);
    }
}
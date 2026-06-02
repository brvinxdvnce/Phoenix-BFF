using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Units.Queries.GetUnits;

public class GetUnitsHandler(
    IGrpcErrorHandler grpcErrorHandler,
    UnitService.UnitServiceClient unitServiceClient
    ) : IRequestHandler<GetUnitsQuery, Result<UnitsResponse>>
{
    public async Task<Result<UnitsResponse>> Handle(GetUnitsQuery request, CancellationToken ct)
    {
        return await unitServiceClient
            .GetUnitsAsync(
                new Empty(), 
                new CallOptions(cancellationToken: ct))
            .ResponseAsync;
    }
}
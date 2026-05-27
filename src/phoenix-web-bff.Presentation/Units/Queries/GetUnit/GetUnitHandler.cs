using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Units.Queries.GetUnit;

public class GetUnitHandler(
    IGrpcErrorHandler grpcErrorHandler,
    UnitService.UnitServiceClient unitServiceClient
    ) : IRequestHandler<GetUnitQuery, Result<UnitResponse>>
{
    public async Task<Result<UnitResponse>> Handle(GetUnitQuery request, CancellationToken ct)
    {
        return await grpcErrorHandler.TryAsync(() =>
            unitServiceClient
                .GetUnitAsync(
                    new Id { Id_ = request.Id },
                    new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}
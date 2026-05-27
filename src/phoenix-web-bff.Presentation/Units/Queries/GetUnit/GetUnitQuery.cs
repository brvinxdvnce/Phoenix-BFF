using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Units.Queries.GetUnit;

public record GetUnitQuery(string Id) : IRequest<Result<UnitResponse>>;
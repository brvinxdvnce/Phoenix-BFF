using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Units.Queries.GetUnits;

public record GetUnitsQuery() : IRequest<Result<UnitsResponse>>;
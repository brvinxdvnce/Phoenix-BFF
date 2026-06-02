using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.IncidentSeverities.Queries.GetAllIncidentSeverities;

public record GetAllIncidentSeveritiesQuery() : IRequest<Result<SeveritiesListResponse>>;
using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Incidents.Queries.GetIncidents;

public record GetIncidentsQuery() : IRequest<Result<IncidentListResponse>>;
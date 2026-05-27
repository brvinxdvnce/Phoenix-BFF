using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Incidents.Queries.GetIncident;

public record GetIncidentQuery(string IncidentId) : IRequest<Result<IncidentResponse>>;
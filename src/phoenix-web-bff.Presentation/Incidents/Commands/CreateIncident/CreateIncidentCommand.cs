using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Incidents.Commands.CreateIncident;

public record CreateIncidentCommand(
    string Title,
    string Description,
    string Status,
    string ReporterId,
    string? AssigneeId 
    ) : IRequest<Result<IncidentResponse>>;
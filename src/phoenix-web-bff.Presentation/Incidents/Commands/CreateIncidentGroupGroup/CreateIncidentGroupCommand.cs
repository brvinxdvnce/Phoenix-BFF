using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Incidents.Commands.CreateIncidentGroupGroup;

public record CreateIncidentGroupCommand(CreateIncidentGroupRequest Request)
    : IRequest<Result<IncidentGroupResponse>>;
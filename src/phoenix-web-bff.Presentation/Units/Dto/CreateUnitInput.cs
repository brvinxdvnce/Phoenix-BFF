namespace phoenix_web_bff.Presentation.Units.Dto;

public record CreateUnitInput(
    string Id,
    string Name,
    string Severity,
    string ParentId
    );
    
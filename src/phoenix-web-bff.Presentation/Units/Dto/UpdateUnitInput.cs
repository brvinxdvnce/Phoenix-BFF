namespace phoenix_web_bff.Presentation.Units.Dto;

public record UpdateUnitInput(
    string Id,
    string Name,
    string Severity,
    string[] SubUnits
    );
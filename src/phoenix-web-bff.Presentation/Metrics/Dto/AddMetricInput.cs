namespace phoenix_web_bff.Presentation.Metrics.Dto;

public record AddMetricInput(
    string Severity,
    string Title,
    string Description,
    string Query,
    double Threshold,
    int ThresholdDirection,
    string? RunbookLinkTemplate,
    string? MonitoringLinkTemplate
    );
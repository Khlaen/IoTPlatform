
namespace IoTPlatform.Application.DTOs;

public class TelemetryDto
{
    public int DeviceAssetId { get; set; }

    public string MetricName { get; set; } = "";

    public decimal Value { get; set; }

    public string Unit { get; set; } = "";
}
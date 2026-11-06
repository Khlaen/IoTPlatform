using IoTPlatform.Domain.Exceptions;

namespace IoTPlatform.Domain.Entities;

public class TelemetryMetric
{
    public int Id { get; private set; }

    public int DeviceAssetId { get; private set; }

    public string MetricName { get; private set; }

    public decimal Value { get; private set; }

    public string Unit { get; private set; }

    public DateTime RecordedAt { get; private set; }

    private TelemetryMetric() { }

    public TelemetryMetric(
        int deviceAssetId,
        string metricName,
        decimal value,
        string unit)
    {
        if (deviceAssetId <= 0)
            throw new DomainException("Invalid device ID.");

        if (string.IsNullOrWhiteSpace(metricName))
            throw new DomainException("Metric name is required.");

        if (string.IsNullOrWhiteSpace(unit))
            throw new DomainException("Unit is required.");

        DeviceAssetId = deviceAssetId;
        MetricName = metricName;
        Value = value;
        Unit = unit;
        RecordedAt = DateTime.UtcNow;
    }
}

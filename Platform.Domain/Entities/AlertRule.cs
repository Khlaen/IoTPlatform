using IoTPlatform.Domain.Exceptions;

namespace IoTPlatform.Domain.Entities;

public class AlertRule
{
    public int Id { get; private set; }

    public int DeviceAssetId { get; private set; }

    public string MetricName { get; private set; }

    public decimal Threshold { get; private set; }

    public bool IsAboveThreshold { get; private set; }

    public bool IsEnabled { get; private set; }

    private AlertRule() { }

    public AlertRule(
        int deviceAssetId,
        string metricName,
        decimal threshold,
        bool isAboveThreshold)
    {
        if (deviceAssetId <= 0)
            throw new DomainException("Invalid device ID.");

        if (string.IsNullOrWhiteSpace(metricName))
            throw new DomainException("Metric name is required.");

        if (threshold <= 0)
            throw new DomainException("Threshold must be positive.");

        DeviceAssetId = deviceAssetId;
        MetricName = metricName;
        Threshold = threshold;
        IsAboveThreshold = isAboveThreshold;
        IsEnabled = true;
    }

    public bool ShouldTrigger(decimal value)
    {
        if (!IsEnabled)
            return false;

        return IsAboveThreshold
            ? value > Threshold
            : value < Threshold;
    }

    public void Disable()
    {
        IsEnabled = false;
    }
}
using IoTPlatform.Domain.Entities;

namespace IoTPlatform.Application.Interfaces;

public interface ITelemetryRepository
{
    Task AddAsync(TelemetryMetric metric);

    Task<IEnumerable<TelemetryMetric>>
        GetByDeviceIdAsync(int deviceId);

    Task SaveChangesAsync();
}
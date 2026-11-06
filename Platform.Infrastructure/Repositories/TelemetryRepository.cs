using IoTPlatform.Application.Interfaces;
using IoTPlatform.Domain.Entities;
using IoTPlatform.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using IoTPlatform.Application.Interfaces;
using IoTPlatform.Domain.Entities;
using IoTPlatform.Infrastructure.Data;

namespace IoTPlatform.Infrastructure.Repositories;

public class TelemetryRepository : ITelemetryRepository
{
    private readonly IoTDbContext _context;

    public TelemetryRepository(IoTDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TelemetryMetric metric)
    {
        await _context.TelemetryMetrics.AddAsync(metric);
    }

    public async Task<IEnumerable<TelemetryMetric>>
        GetByDeviceIdAsync(int deviceId)
    {
        return await _context.TelemetryMetrics
            .Where(t => t.DeviceAssetId == deviceId)
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
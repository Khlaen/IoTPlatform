using IoTPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IoTPlatform.Infrastructure.Data;

public class IoTDbContext : DbContext
{
    public IoTDbContext(DbContextOptions<IoTDbContext> options)
        : base(options)
    {
    }

    public DbSet<DeviceAsset> Devices => Set<DeviceAsset>();

    public DbSet<TelemetryMetric> TelemetryMetrics =>
        Set<TelemetryMetric>();

    public DbSet<AlertRule> AlertRules => Set<AlertRule>();

    public DbSet<MaintenanceLog> MaintenanceLogs =>
        Set<MaintenanceLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(IoTDbContext).Assembly);
    }
}
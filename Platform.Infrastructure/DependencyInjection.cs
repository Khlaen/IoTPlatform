using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IoTPlatform.Application.Interfaces;
using IoTPlatform.Infrastructure.Data;
using IoTPlatform.Infrastructure.Repositories;

namespace IoTPlatform.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<IoTDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IDeviceRepository, DeviceRepository>();

        services.AddScoped<ITelemetryRepository, TelemetryRepository>();

        return services;
    }
}

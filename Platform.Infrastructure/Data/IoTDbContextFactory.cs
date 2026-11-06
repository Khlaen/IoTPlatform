using IoTPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IoTPlatform.Infrastructure.Data;

public class IoTDbContextFactory
    : IDesignTimeDbContextFactory<IoTDbContext>
{
    public IoTDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<IoTDbContext>();

        var connectionString =
    "Server=.\\SQLEXPRESS;Database=IoTPlatformDb;Trusted_Connection=True;TrustServerCertificate=True;";

        optionsBuilder.UseSqlServer(connectionString);

        return new IoTDbContext(optionsBuilder.Options);
    }
}

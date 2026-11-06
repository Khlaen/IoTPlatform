using IoTPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var connectionString =
    "Server=(localdb)\\MSSQLLocalDB;Database=IoTPlatformDb;Trusted_Connection=True;TrustServerCertificate=True;";

var options = new DbContextOptionsBuilder<IoTDbContext>()
    .UseSqlServer(connectionString)
    .Options;

using var dbContext = new IoTDbContext(options);

Console.WriteLine("Migration runner configured.");
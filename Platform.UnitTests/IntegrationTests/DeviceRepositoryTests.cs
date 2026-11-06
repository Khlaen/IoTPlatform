using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

using IoTPlatform.Domain.Entities;
using IoTPlatform.Domain.ValueObjects;
using IoTPlatform.Infrastructure.Data;
using IoTPlatform.Infrastructure.Repositories;

namespace IoTPlatform.UnitTests.IntegrationTests;

[TestClass]
public class DeviceRepositoryTests
{
    private SqliteConnection _connection = null!;

    private IoTDbContext _context = null!;

    private DeviceRepository _repository = null!;

    [TestInitialize]
    public void Setup()
    {
        _connection = new SqliteConnection("Data Source=:memory:");

        _connection.Open();

        var options = new DbContextOptionsBuilder<IoTDbContext>()
            .UseSqlite(_connection)
            .Options;

        _context = new IoTDbContext(options);

        _context.Database.EnsureCreated();

        _repository = new DeviceRepository(_context);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _context.Dispose();
        _connection.Dispose();
    }

    private DeviceAsset CreateDevice()
    {
        return new DeviceAsset(
            SerialNumber.Create("IOT-ABC-1234"),
            "Temperature Sensor",
            "Factory A",
            OperatingLimits.Create(1, 100));
    }

    [TestMethod]
    public async Task AddAsync_Device_SavesToDatabase()
    {
        var device = CreateDevice();

        await _repository.AddAsync(device);

        await _repository.SaveChangesAsync();

        var result = await _repository.GetAllAsync();

        Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    public async Task GetByIdAsync_ExistingDevice_ReturnsDevice()
    {
        var device = CreateDevice();

        await _repository.AddAsync(device);

        await _repository.SaveChangesAsync();

        var result = await _repository.GetByIdAsync(device.Id);

        Assert.IsNotNull(result);

        Assert.AreEqual("Temperature Sensor", result.Name);
    }

    [TestMethod]
    public async Task DeleteAsync_ExistingDevice_RemovesDevice()
    {
        var device = CreateDevice();

        await _repository.AddAsync(device);

        await _repository.SaveChangesAsync();

        await _repository.DeleteAsync(device.Id);

        await _repository.SaveChangesAsync();

        var result = await _repository.GetByIdAsync(device.Id);

        Assert.IsNull(result);
    }
}
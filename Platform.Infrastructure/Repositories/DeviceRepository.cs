using Microsoft.EntityFrameworkCore;
using IoTPlatform.Application.Interfaces;
using IoTPlatform.Domain.Entities;
using IoTPlatform.Infrastructure.Data;

namespace IoTPlatform.Infrastructure.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private readonly IoTDbContext _context;

    public DeviceRepository(IoTDbContext context)
    {
        _context = context;
    }

    public async Task<DeviceAsset?> GetByIdAsync(int id)
    {
        return await _context.Devices
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<IEnumerable<DeviceAsset>> GetAllAsync()
    {
        return await _context.Devices.ToListAsync();
    }

    public async Task AddAsync(DeviceAsset device)
    {
        await _context.Devices.AddAsync(device);
    }

    public Task UpdateAsync(DeviceAsset device)
    {
        _context.Devices.Update(device);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var device = await GetByIdAsync(id);

        if (device != null)
            _context.Devices.Remove(device);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
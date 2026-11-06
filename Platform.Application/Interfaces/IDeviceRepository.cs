using IoTPlatform.Domain.Entities;

namespace IoTPlatform.Application.Interfaces;

public interface IDeviceRepository
{
    Task<DeviceAsset?> GetByIdAsync(int id);

    Task<IEnumerable<DeviceAsset>> GetAllAsync();

    Task AddAsync(DeviceAsset device);

    Task UpdateAsync(DeviceAsset device);

    Task DeleteAsync(int id);

    Task SaveChangesAsync();
}

using IoTPlatform.Application.DTOs;

namespace IoTPlatform.Application.Services;

public interface IDeviceService
{
    Task<DeviceDto?> GetDeviceAsync(int id);

    Task<IEnumerable<DeviceDto>> GetAllDevicesAsync();
}

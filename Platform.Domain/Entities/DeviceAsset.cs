using IoTPlatform.Domain.Exceptions;
using IoTPlatform.Domain.ValueObjects;

namespace IoTPlatform.Domain.Entities;

public enum DeviceStatus
{
    Registered,
    Active,
    UnderMaintenance,
    Retired
}

public class DeviceAsset
{
    public int Id { get; private set; }

    public SerialNumber SerialNumber { get; private set; }

    public string Name { get; private set; }

    public string Location { get; private set; }

    public DeviceStatus Status { get; private set; }

    public OperatingLimits OperatingLimits { get; private set; }

    private DeviceAsset() { }

    public DeviceAsset(
        SerialNumber serialNumber,
        string name,
        string location,
        OperatingLimits operatingLimits)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Device name is required.");

        if (string.IsNullOrWhiteSpace(location))
            throw new DomainException("Device location is required.");

        SerialNumber = serialNumber
            ?? throw new DomainException("Serial number is required.");

        OperatingLimits = operatingLimits
            ?? throw new DomainException("Operating limits are required.");

        Name = name;
        Location = location;
        Status = DeviceStatus.Registered;
    }

    public void ChangeStatus(DeviceStatus newStatus)
    {
        bool valid =
            (Status == DeviceStatus.Registered &&
                (newStatus == DeviceStatus.Active ||
                 newStatus == DeviceStatus.Retired))

            ||

            (Status == DeviceStatus.Active &&
                (newStatus == DeviceStatus.UnderMaintenance ||
                 newStatus == DeviceStatus.Retired))

            ||

            (Status == DeviceStatus.UnderMaintenance &&
                (newStatus == DeviceStatus.Active ||
                 newStatus == DeviceStatus.Retired));

        if (!valid)
            throw new DomainException(
                $"Cannot change status from {Status} to {newStatus}.");

        Status = newStatus;
    }
}

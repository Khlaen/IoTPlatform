using IoTPlatform.Domain.Exceptions;

namespace IoTPlatform.Domain.Entities;

public class MaintenanceLog
{
    public int Id { get; private set; }

    public int DeviceAssetId { get; private set; }

    public string Description { get; private set; }

    public string TechnicianName { get; private set; }

    public DateTime MaintenanceDate { get; private set; }

    private MaintenanceLog() { }

    public MaintenanceLog(
        int deviceAssetId,
        string description,
        string technicianName)
    {
        if (deviceAssetId <= 0)
            throw new DomainException("Invalid device ID.");

        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("Description is required.");

        if (string.IsNullOrWhiteSpace(technicianName))
            throw new DomainException("Technician name is required.");

        DeviceAssetId = deviceAssetId;
        Description = description;
        TechnicianName = technicianName;
        MaintenanceDate = DateTime.UtcNow;
    }
}

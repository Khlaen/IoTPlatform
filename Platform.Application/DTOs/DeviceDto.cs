namespace IoTPlatform.Application.DTOs;

public class DeviceDto
{
    public int Id { get; set; }

    public string SerialNumber { get; set; } = "";

    public string Name { get; set; } = "";

    public string Location { get; set; } = "";

    public string Status { get; set; } = "";
}

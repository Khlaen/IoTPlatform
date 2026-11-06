using System.Text.Json;
using IoTPlatform.Domain.Entities;
using IoTPlatform.Domain.ValueObjects;

namespace IoTPlatform.Infrastructure.Seed;

public static class DeviceSeedLoader
{
    public static async Task<List<DeviceAsset>> LoadAsync(
        string filePath)
    {
        var json = await File.ReadAllTextAsync(filePath);

        var records = JsonSerializer.Deserialize<List<DeviceSeedData>>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        if (records == null)
            return new List<DeviceAsset>();

        return records.Select(record =>
            new DeviceAsset(
                SerialNumber.Create(record.SerialNumber),
                record.Name,
                record.Location,
                OperatingLimits.Create(
                    record.MinimumLimit,
                    record.MaximumLimit)
            )).ToList();
    }

    private class DeviceSeedData
    {
        public string SerialNumber { get; set; } = "";

        public string Name { get; set; } = "";

        public string Location { get; set; } = "";

        public decimal MinimumLimit { get; set; }

        public decimal MaximumLimit { get; set; }
    }
}
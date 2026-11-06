using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IoTPlatform.Domain.Entities;
using IoTPlatform.Domain.ValueObjects;

namespace IoTPlatform.Infrastructure.Data.Configurations;

public class DeviceAssetConfiguration :
    IEntityTypeConfiguration<DeviceAsset>
{
    public void Configure(EntityTypeBuilder<DeviceAsset> builder)
    {
        builder.ToTable("Devices");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Location)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(d => d.Status)
            .HasConversion<string>()
            .HasMaxLength(30);

        builder.OwnsOne(d => d.SerialNumber, serial =>
        {
            serial.Property(s => s.Value)
                .HasColumnName("SerialNumber")
                .HasMaxLength(12)
                .IsRequired();

            serial.HasIndex(s => s.Value)
                .IsUnique();
        });

        builder.OwnsOne(d => d.OperatingLimits, limits =>
        {
            limits.Property(l => l.Minimum)
                .HasColumnName("MinimumLimit")
                .HasPrecision(18, 2);

            limits.Property(l => l.Maximum)
                .HasColumnName("MaximumLimit")
                .HasPrecision(18, 2);
        });
    }
}
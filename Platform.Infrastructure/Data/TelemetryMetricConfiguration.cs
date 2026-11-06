using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IoTPlatform.Domain.Entities;

namespace IoTPlatform.Infrastructure.Data.Configurations;

public class TelemetryMetricConfiguration :
    IEntityTypeConfiguration<TelemetryMetric>
{
    public void Configure(EntityTypeBuilder<TelemetryMetric> builder)
    {
        builder.ToTable("TelemetryMetrics", table =>
        {
            table.HasCheckConstraint(
                "CK_Telemetry_DeviceId",
                "[DeviceAssetId] > 0");
        });

        builder.HasKey(t => t.Id);

        builder.Property(t => t.MetricName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.Unit)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(t => t.Value)
            .HasPrecision(18, 2);

        builder.Property(t => t.RecordedAt)
            .IsRequired();

        builder.HasOne<DeviceAsset>()
            .WithMany()
            .HasForeignKey(t => t.DeviceAssetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(t => new
        {
            t.DeviceAssetId,
            t.RecordedAt
        });
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IoTPlatform.Domain.Entities;

namespace IoTPlatform.Infrastructure.Data.Configurations;

public class MaintenanceLogConfiguration :
    IEntityTypeConfiguration<MaintenanceLog>
{
    public void Configure(EntityTypeBuilder<MaintenanceLog> builder)
    {
        builder.ToTable("MaintenanceLogs");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(m => m.TechnicianName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.MaintenanceDate)
            .IsRequired();

        builder.HasOne<DeviceAsset>()
            .WithMany()
            .HasForeignKey(m => m.DeviceAssetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(m => m.DeviceAssetId);
    }
}
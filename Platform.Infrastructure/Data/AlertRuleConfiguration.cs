using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IoTPlatform.Domain.Entities;

namespace IoTPlatform.Infrastructure.Data.Configurations;

public class AlertRuleConfiguration :
    IEntityTypeConfiguration<AlertRule>
{
    public void Configure(EntityTypeBuilder<AlertRule> builder)
    {
        builder.ToTable("AlertRules", table =>
        {
            table.HasCheckConstraint(
                "CK_AlertRule_Threshold",
                "[Threshold] > 0");
        });

        builder.HasKey(a => a.Id);

        builder.Property(a => a.MetricName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.Threshold)
            .HasPrecision(18, 2);

        builder.HasOne<DeviceAsset>()
            .WithMany()
            .HasForeignKey(a => a.DeviceAssetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(a => a.DeviceAssetId);
    }
}

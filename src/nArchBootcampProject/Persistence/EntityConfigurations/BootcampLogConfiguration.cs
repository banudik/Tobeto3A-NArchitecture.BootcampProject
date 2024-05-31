using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BootcampLogConfiguration : IEntityTypeConfiguration<BootcampLog>
{
    public void Configure(EntityTypeBuilder<BootcampLog> builder)
    {
        builder.ToTable("BootcampLogs").HasKey(bl => bl.Id);

        builder.Property(bl => bl.Id).HasColumnName("Id").IsRequired();
        builder.Property(bl => bl.BootcampId).HasColumnName("BootcampId");
        builder.Property(bl => bl.ChapterId).HasColumnName("ChapterId");
        builder.Property(bl => bl.UserId).HasColumnName("UserId");
        builder.Property(bl => bl.Status).HasColumnName("Status");
        builder.Property(bl => bl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bl => bl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bl => bl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(bl => !bl.DeletedDate.HasValue);

        builder.HasOne(p => p.Bootcamp);
        builder.HasOne(p => p.User);
    }
}
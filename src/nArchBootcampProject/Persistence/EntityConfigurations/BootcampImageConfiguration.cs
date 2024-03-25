using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BootcampImageConfiguration : IEntityTypeConfiguration<BootcampImage>
{
    public void Configure(EntityTypeBuilder<BootcampImage> builder)
    {
        builder.ToTable("BootcampImages");

        builder.Property(bi => bi.Id).HasColumnName("Id").IsRequired();
        builder.Property(bi => bi.BootcampId).HasColumnName("BootcampId");
        builder.Property(bi => bi.ImagePath).HasColumnName("ImagePath");
        builder.Property(bi => bi.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bi => bi.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bi => bi.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(x => x.Bootcamp);
        builder.HasQueryFilter(bi => !bi.DeletedDate.HasValue);
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ApplicationStateInformationConfiguration : IEntityTypeConfiguration<ApplicationStateInformation>
{
    public void Configure(EntityTypeBuilder<ApplicationStateInformation> builder)
    {
        builder.ToTable("ApplicationStateInformations");

        builder.Property(asi => asi.Id).HasColumnName("Id").IsRequired();
        builder.Property(asi => asi.Name).HasColumnName("Name");
        builder.Property(asi => asi.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(asi => asi.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(asi => asi.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(asi => !asi.DeletedDate.HasValue);
    }
}

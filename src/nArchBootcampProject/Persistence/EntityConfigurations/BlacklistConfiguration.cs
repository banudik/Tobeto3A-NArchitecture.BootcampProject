using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BlacklistConfiguration : IEntityTypeConfiguration<Blacklist>
{
    public void Configure(EntityTypeBuilder<Blacklist> builder)
    {
        builder.ToTable("Blacklists");

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Reason).HasColumnName("Reason");
        builder.Property(b => b.Date).HasColumnName("Date");
        builder.Property(b => b.ApplicantId).HasColumnName("ApplicantId");
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(x => x.Applicant);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}

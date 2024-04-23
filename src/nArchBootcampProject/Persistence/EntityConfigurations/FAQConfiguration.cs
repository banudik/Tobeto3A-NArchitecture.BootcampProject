using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FAQConfiguration : IEntityTypeConfiguration<FAQ>
{
    public void Configure(EntityTypeBuilder<FAQ> builder)
    {
        builder.ToTable("FAQs").HasKey(faq => faq.Id);

        builder.Property(faq => faq.Id).HasColumnName("Id").IsRequired();
        builder.Property(faq => faq.Question).HasColumnName("Question");
        builder.Property(faq => faq.Answer).HasColumnName("Answer");
        builder.Property(faq => faq.Category).HasColumnName("Category");
        builder.Property(faq => faq.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(faq => faq.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(faq => faq.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(faq => !faq.DeletedDate.HasValue);
    }
}
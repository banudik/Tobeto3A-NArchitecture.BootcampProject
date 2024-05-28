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

    public static short AdminId => 1;
    private IEnumerable<ApplicationStateInformation> _seeds
    {
        get
        {
            //yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<ApplicationStateInformation> featureOperationClaims = getFeaturBootcampStates(AdminId);
            foreach (ApplicationStateInformation claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<ApplicationStateInformation> getFeaturBootcampStates(short initialId)
    {
        short lastId = initialId;
        List<ApplicationStateInformation> featureOperationClaims = new();


        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = "Received" },
                new() { Id = ++lastId, Name = "Approved" },
                new() { Id = ++lastId, Name = "Un Approved" },
                new() { Id = ++lastId, Name = "Cancelled" }
            ]
        );

        return featureOperationClaims;
    }
}

using Application.Features.Auth.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;

namespace Persistence.EntityConfigurations;

public class BootcampStateConfiguration : IEntityTypeConfiguration<BootcampState>
{
    public void Configure(EntityTypeBuilder<BootcampState> builder)
    {
        builder.ToTable("BootcampStates");

        builder.Property(bs => bs.Id).HasColumnName("Id").IsRequired();
        builder.Property(bs => bs.Name).HasColumnName("Name");
        builder.Property(bs => bs.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bs => bs.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bs => bs.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(bs => !bs.DeletedDate.HasValue);
        builder.HasData(GetSeeds()); //elle ekledim
    }

    private static BootcampState[] GetSeeds()
    {
        return
        [
                new BootcampState { Id = 1, Name = "Not Started", CreatedDate = DateTime.UtcNow },
                new BootcampState { Id = 2, Name = "Started", CreatedDate = DateTime.UtcNow },
                new BootcampState { Id = 3, Name = "On Hold", CreatedDate = DateTime.UtcNow },
                new BootcampState { Id = 4, Name = "Finished", CreatedDate = DateTime.UtcNow }
        ];
    }
}

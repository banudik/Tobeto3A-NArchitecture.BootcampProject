using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Hashing;

namespace Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.UserName).HasColumnName("UserName");
        builder.Property(u => u.FirstName).HasColumnName("FirstName");
        builder.Property(u => u.LastName).HasColumnName("LastName");
        builder.Property(u => u.DateOfBirth).HasColumnName("DateOfBirth");
        builder.Property(u => u.NationalIdentity).HasColumnName("NationalIdentity");
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType").IsRequired();
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasMany(u => u.UserOperationClaims);
        builder.HasMany(u => u.RefreshTokens);
        builder.HasMany(u => u.EmailAuthenticators);
        builder.HasMany(u => u.OtpAuthenticators);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static Guid AdminId { get; } = Guid.NewGuid();
    private IEnumerable<User> _seeds
    {
        get
        {
            HashingHelper.CreatePasswordHash(
                password: "Passw0rd!",
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User adminUser =
                new()
                {
                    FirstName = "Banu",
                    LastName = "Dik",
                    UserName = "banudik",
                    NationalIdentity = "TC1246",
                    DateOfBirth = DateTime.Now,
                    Id = AdminId,
                    Email = "banudik_34@hotmail.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
            yield return adminUser;
        }
    }
}

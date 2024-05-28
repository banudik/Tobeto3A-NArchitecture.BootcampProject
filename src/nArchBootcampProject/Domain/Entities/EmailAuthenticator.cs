namespace Domain.Entities;

public class EmailAuthenticator : NArchitecture.Core.Security.Entities.EmailAuthenticator<Guid>
{
    public bool ResetPasswordToken { get; set; }
    public DateTime? ResetPasswordTokenExpiry { get; set; }
    public virtual User User { get; set; } = default!;
}

using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Blacklist : Entity<int>
{
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public Guid ApplicantId { get; set; }

    public virtual Applicant? Applicant { get; set; }

    public Blacklist() { }

    public Blacklist(string reason, DateTime date, Guid applicantId, Applicant applicant)
    {
        Reason = reason;
        Date = date;
        ApplicantId = applicantId;
        Applicant = applicant;
    }
}

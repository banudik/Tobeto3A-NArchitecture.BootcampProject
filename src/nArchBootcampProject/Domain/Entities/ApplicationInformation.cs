using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class ApplicationInformation : Entity<int>
{
    public Guid ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public short ApplicationStateInformationId { get; set; }

    public virtual Applicant? Applicant { get; set; }
    public virtual Bootcamp? Bootcamp { get; set; }
    public virtual ApplicationStateInformation? ApplicationStateInformation { get; set; }

    public ApplicationInformation() { }

    public ApplicationInformation(
        Guid applicantId,
        int bootcampId,
        short applicationStateInformationId,
        Applicant? applicant,
        Bootcamp? bootcamp,
        ApplicationStateInformation? applicationStateInformation
    )
    {
        ApplicantId = applicantId;
        BootcampId = bootcampId;
        ApplicationStateInformationId = applicationStateInformationId;
        Applicant = applicant;
        Bootcamp = bootcamp;
        ApplicationStateInformation = applicationStateInformation;
    }
}

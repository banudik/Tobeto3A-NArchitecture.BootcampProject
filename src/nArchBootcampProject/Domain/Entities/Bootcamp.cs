using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Bootcamp : Entity<int>
{
    public string Name { get; set; }
    public Guid InstructorId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public short BootcampStateId { get; set; }
    public int BootcampImageId { get; set; }
    public virtual Instructor? Instructor { get; set; }
    public virtual ICollection<ApplicationInformation> ApplicationInformations { get; set; }
    public virtual BootcampState BootcampState { get; set; }
    public virtual BootcampImage? BootcampImage { get; set; }
    public string Description { get; set; }

    public Bootcamp()
    {
        ApplicationInformations = new HashSet<ApplicationInformation>();
    }

    public Bootcamp(
        string name,
        Guid instructorId,
        DateTime startDate,
        DateTime endDate,
        short bootcampStateId,
        Instructor? instructor,
        ICollection<ApplicationInformation> applicationInformations,
        BootcampState bootcampState,
        BootcampImage bootcampImage,
        int bootcampImageId
    )
    {
        Name = name;
        InstructorId = instructorId;
        StartDate = startDate;
        EndDate = endDate;
        BootcampStateId = bootcampStateId;
        Instructor = instructor;
        ApplicationInformations = applicationInformations;
        BootcampState = bootcampState;
        BootcampImage = bootcampImage;
        BootcampImageId = bootcampImageId;
    }
}

using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class BootcampImage : Entity<int>
{
    public int BootcampId { get; set; }
    public string ImagePath { get; set; }
    public virtual Bootcamp? Bootcamp { get; set; }

    public BootcampImage() { }

    public BootcampImage(int bootcampId, string imagePath, Bootcamp? bootcamp)
    {
        BootcampId = bootcampId;
        ImagePath = imagePath;
        Bootcamp = bootcamp;
    }
}

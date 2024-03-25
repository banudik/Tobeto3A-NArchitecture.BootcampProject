using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class BootcampState : Entity<short>
{
    public string Name { get; set; }

    public BootcampState() { }

    public BootcampState(string name)
    {
        Name = name;
    }
}

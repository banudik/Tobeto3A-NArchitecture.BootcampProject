using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Certificate : Entity<Guid>
{
    public Guid UserId { get; set; }
    public int BootcampId { get; set; }
    public virtual User User { get; set; }
    public virtual Bootcamp Bootcamp { get; set; }

    public Certificate() {}

    public Certificate(Guid id,Guid applicantId, int bootcampId)
    {
        Id = id;
        UserId = applicantId;
        BootcampId = bootcampId;
    }
}

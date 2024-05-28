using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BootcampLog:Entity<int>
{
    public int BootcampId { get; set; }
    public int ChapterId { get; set; }
    public Guid UserId { get; set; }
    public bool Status { get; set; }
    public virtual Bootcamp Bootcamp { get; set; }
    public virtual User User { get; set; }
}

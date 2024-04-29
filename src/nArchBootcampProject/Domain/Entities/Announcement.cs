using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Announcement : Entity<int>
{
    //Duyurular
    public string Header { get; set; }
    public string Description { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Instructor : User
{
    public string CompanyName { get; set; }
    public string Description { get; set; }

    //public virtual Bootcamp? Bootcamps { get; set; }

    public Instructor() { }

    public Instructor(string companyName)
    {
        CompanyName = companyName;
    }
}

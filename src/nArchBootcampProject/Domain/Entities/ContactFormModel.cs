using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ContactFormModel 
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }

    public ContactFormModel()
    {
    }

    public ContactFormModel(string name, string email, string message)
    {
        Name = name;
        Email = email;
        Message = message;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Register;
public class EmployeeRegisterDto : RegisterDto
{
    public string Position { get; set; }
}



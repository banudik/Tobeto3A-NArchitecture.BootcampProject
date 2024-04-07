using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Register;

public class InstructorRegisterDto : RegisterDto
{
    public string CompanyName { get; set; }
}

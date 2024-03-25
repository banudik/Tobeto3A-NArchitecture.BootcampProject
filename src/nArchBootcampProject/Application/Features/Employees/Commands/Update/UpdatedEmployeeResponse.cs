using NArchitecture.Core.Application.Responses;

namespace Application.Features.Employees.Commands.Update;

public class UpdatedEmployeeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Position { get; set; }
}

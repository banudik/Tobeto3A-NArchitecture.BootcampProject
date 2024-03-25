using NArchitecture.Core.Application.Responses;

namespace Application.Features.Employees.Queries.GetById;

public class GetByIdEmployeeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Position { get; set; }
}

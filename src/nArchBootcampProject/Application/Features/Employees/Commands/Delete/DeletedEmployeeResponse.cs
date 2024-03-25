using NArchitecture.Core.Application.Responses;

namespace Application.Features.Employees.Commands.Delete;

public class DeletedEmployeeResponse : IResponse
{
    public Guid Id { get; set; }
}

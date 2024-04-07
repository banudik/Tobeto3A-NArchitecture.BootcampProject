using NArchitecture.Core.Application.Responses;

namespace Application.Features.Employees.Commands.Delete;

public class DeletedEmployeeResponse : IResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string Position { get; set; }
}

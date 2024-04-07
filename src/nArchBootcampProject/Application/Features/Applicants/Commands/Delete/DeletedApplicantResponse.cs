using NArchitecture.Core.Application.Responses;

namespace Application.Features.Applicants.Commands.Delete;

public class DeletedApplicantResponse : IResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string About { get; set; }
}

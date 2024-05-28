using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Applicants.Queries.GetList;

public class GetListApplicantListItemDto : IDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string About { get; set; }
    public DateTime CreatedDate { get; set; }
}

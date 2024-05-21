using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ApplicationInformations.Queries.GetList;

public class GetListApplicationInformationListItemDto : IDto
{
    public int Id { get; set; }
    public Guid ApplicantId { get; set; }
    public string ApplicantFirstName { get; set; }
    public string ApplicantLastName { get; set; }
    public int BootcampId { get; set; }
    public string BootcampName { get; set; }
    public string ApplicationStateInformationName { get; set; }
    public short ApplicationStateInformationId { get; set; }
    public DateTime CreatedDate { get; set; }
}

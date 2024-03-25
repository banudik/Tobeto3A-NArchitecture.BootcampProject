using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ApplicationInformations.Queries.GetList;

public class GetListApplicationInformationListItemDto : IDto
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public int ApplicationStateId { get; set; }
}

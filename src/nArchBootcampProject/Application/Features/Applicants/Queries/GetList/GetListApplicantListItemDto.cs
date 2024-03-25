using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Applicants.Queries.GetList;

public class GetListApplicantListItemDto : IDto
{
    public Guid Id { get; set; }
    public string About { get; set; }
}

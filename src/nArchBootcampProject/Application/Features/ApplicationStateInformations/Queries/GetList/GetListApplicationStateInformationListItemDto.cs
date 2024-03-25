using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ApplicationStateInformations.Queries.GetList;

public class GetListApplicationStateInformationListItemDto : IDto
{
    public short Id { get; set; }
    public string Name { get; set; }
}

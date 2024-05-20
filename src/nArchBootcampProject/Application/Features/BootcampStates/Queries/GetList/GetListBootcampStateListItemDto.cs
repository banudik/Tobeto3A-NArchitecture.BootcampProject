using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BootcampStates.Queries.GetList;

public class GetListBootcampStateListItemDto : IDto
{
    public short Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}

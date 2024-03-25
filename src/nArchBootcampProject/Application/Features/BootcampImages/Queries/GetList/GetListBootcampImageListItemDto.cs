using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BootcampImages.Queries.GetList;

public class GetListBootcampImageListItemDto : IDto
{
    public int Id { get; set; }
    public int BootcampId { get; set; }
    public string ImagePath { get; set; }
}

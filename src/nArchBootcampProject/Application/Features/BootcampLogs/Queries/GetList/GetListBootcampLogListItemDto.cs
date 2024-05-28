using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BootcampLogs.Queries.GetList;

public class GetListBootcampLogListItemDto : IDto
{
    public int Id { get; set; }
    public int BootcampId { get; set; }
    public int ChapterId { get; set; }
    public Guid UserId { get; set; }
    public bool Status { get; set; }
}
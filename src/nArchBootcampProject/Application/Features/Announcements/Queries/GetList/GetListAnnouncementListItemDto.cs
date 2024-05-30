using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Announcements.Queries.GetList;

public class GetListAnnouncementListItemDto : IDto
{
    public int Id { get; set; }
    public string Header { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
}
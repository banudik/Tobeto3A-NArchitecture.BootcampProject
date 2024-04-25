using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Chapters.Queries.GetList;

public class GetListChapterListItemDto : IDto
{
    public int Id { get; set; }
    public int Sort { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string Link { get; set; }
    public int BootcampId { get; set; }
    public int Time { get; set; }
}
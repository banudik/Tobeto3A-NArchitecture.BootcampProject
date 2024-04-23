using NArchitecture.Core.Application.Responses;

namespace Application.Features.Chapters.Commands.Update;

public class UpdatedChapterResponse : IResponse
{
    public int Id { get; set; }
    public int Sort { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string Link { get; set; }
    public int BootcampId { get; set; }
    public int Time { get; set; }
}
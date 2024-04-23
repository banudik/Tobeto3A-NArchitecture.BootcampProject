using NArchitecture.Core.Application.Responses;

namespace Application.Features.Chapters.Commands.Delete;

public class DeletedChapterResponse : IResponse
{
    public int Id { get; set; }
}
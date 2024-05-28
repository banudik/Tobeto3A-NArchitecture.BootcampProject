using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Comments.Queries.GetList;

public class GetListCommentListItemDto : IDto
{
    public int Id { get; set; }
    public string Context { get; set; }
    public int ChapterId { get; set; }
    public int ChapterSort { get; set; }
    public string ChapterBootcampName { get; set; }
    public Guid UserId { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public bool Status { get; set; }
}
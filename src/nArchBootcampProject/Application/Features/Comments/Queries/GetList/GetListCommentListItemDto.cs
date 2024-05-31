using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Comments.Queries.GetList;

public class GetListCommentListItemDto : IDto
{
    public int Id { get; set; }
    public string Context { get; set; }
    public int BootcampId { get; set; }
    public string BootcampName { get; set; }
    public Guid UserId { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public bool Status { get; set; }
}
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Comments.Queries.GetById;

public class GetByIdCommentResponse : IResponse
{
    public int Id { get; set; }
    public string Context { get; set; }
    public int BootcampId { get; set; }
    public Guid UserId { get; set; }
    public bool Status { get; set; }
}
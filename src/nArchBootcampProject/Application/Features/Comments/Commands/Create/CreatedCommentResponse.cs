using NArchitecture.Core.Application.Responses;

namespace Application.Features.Comments.Commands.Create;

public class CreatedCommentResponse : IResponse
{
    public int Id { get; set; }
    public string Context { get; set; }
    public int BootcampId { get; set; }
    public Guid UserId { get; set; }
    public bool Status { get; set; }
}
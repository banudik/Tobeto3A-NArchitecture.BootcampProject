using NArchitecture.Core.Application.Responses;

namespace Application.Features.Comments.Commands.Delete;

public class DeletedCommentResponse : IResponse
{
    public int Id { get; set; }
}
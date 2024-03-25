using NArchitecture.Core.Application.Responses;

namespace Application.Features.Bootcamps.Commands.Delete;

public class DeletedBootcampResponse : IResponse
{
    public int Id { get; set; }
}

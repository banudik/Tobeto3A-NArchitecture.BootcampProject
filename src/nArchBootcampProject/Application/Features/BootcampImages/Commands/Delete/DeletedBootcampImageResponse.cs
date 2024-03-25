using NArchitecture.Core.Application.Responses;

namespace Application.Features.BootcampImages.Commands.Delete;

public class DeletedBootcampImageResponse : IResponse
{
    public int Id { get; set; }
}

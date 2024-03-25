using NArchitecture.Core.Application.Responses;

namespace Application.Features.BootcampImages.Commands.Create;

public class CreatedBootcampImageResponse : IResponse
{
    public int Id { get; set; }
    public int BootcampId { get; set; }
    public string ImagePath { get; set; }
}

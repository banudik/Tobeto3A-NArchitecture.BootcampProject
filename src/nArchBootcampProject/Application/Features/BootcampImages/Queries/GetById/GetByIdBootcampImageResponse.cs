using NArchitecture.Core.Application.Responses;

namespace Application.Features.BootcampImages.Queries.GetById;

public class GetByIdBootcampImageResponse : IResponse
{
    public int Id { get; set; }
    public int BootcampId { get; set; }
    public string ImagePath { get; set; }
}

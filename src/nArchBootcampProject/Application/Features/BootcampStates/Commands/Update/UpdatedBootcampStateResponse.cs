using NArchitecture.Core.Application.Responses;

namespace Application.Features.BootcampStates.Commands.Update;

public class UpdatedBootcampStateResponse : IResponse
{
    public short Id { get; set; }
    public string Name { get; set; }
}

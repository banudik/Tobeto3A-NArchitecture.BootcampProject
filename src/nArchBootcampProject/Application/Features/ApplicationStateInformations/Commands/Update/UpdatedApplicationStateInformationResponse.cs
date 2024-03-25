using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationStateInformations.Commands.Update;

public class UpdatedApplicationStateInformationResponse : IResponse
{
    public short Id { get; set; }
    public string Name { get; set; }
}

using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationStateInformations.Commands.Create;

public class CreatedApplicationStateInformationResponse : IResponse
{
    public short Id { get; set; }
    public string Name { get; set; }
}

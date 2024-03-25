using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationStateInformations.Commands.Delete;

public class DeletedApplicationStateInformationResponse : IResponse
{
    public short Id { get; set; }
}

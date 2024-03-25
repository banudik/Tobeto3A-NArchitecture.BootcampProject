using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationInformations.Commands.Delete;

public class DeletedApplicationInformationResponse : IResponse
{
    public int Id { get; set; }
}

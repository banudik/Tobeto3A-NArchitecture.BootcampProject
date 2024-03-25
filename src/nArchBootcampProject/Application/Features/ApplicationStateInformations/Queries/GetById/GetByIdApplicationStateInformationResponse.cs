using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationStateInformations.Queries.GetById;

public class GetByIdApplicationStateInformationResponse : IResponse
{
    public short Id { get; set; }
    public string Name { get; set; }
}

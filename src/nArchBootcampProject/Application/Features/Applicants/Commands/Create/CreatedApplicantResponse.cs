using NArchitecture.Core.Application.Responses;

namespace Application.Features.Applicants.Commands.Create;

public class CreatedApplicantResponse : IResponse
{
    public Guid Id { get; set; }
    public string About { get; set; }
}

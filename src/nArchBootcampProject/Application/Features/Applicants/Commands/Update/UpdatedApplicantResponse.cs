using NArchitecture.Core.Application.Responses;

namespace Application.Features.Applicants.Commands.Update;

public class UpdatedApplicantResponse : IResponse
{
    public Guid Id { get; set; }
    public string About { get; set; }
}

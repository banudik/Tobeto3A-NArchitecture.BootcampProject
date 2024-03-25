using NArchitecture.Core.Application.Responses;

namespace Application.Features.Applicants.Queries.GetById;

public class GetByIdApplicantResponse : IResponse
{
    public Guid Id { get; set; }
    public string About { get; set; }
}

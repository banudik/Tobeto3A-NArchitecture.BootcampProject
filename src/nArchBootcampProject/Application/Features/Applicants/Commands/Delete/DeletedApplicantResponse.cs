using NArchitecture.Core.Application.Responses;

namespace Application.Features.Applicants.Commands.Delete;

public class DeletedApplicantResponse : IResponse
{
    public Guid Id { get; set; }
}

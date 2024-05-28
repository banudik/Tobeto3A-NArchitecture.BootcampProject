using NArchitecture.Core.Application.Responses;

namespace Application.Features.Certificates.Commands.Delete;

public class DeletedCertificateResponse : IResponse
{
    public Guid Id { get; set; }
}
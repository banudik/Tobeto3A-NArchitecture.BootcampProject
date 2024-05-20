using FluentValidation;

namespace Application.Features.Certificates.Commands.Delete;

public class DeleteCertificateCommandValidator : AbstractValidator<DeleteCertificateCommand>
{
    public DeleteCertificateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
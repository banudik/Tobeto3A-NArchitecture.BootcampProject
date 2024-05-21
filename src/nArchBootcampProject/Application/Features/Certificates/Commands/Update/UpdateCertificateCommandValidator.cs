using FluentValidation;

namespace Application.Features.Certificates.Commands.Update;

public class UpdateCertificateCommandValidator : AbstractValidator<UpdateCertificateCommand>
{
    public UpdateCertificateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ApplicantId).NotEmpty();
        RuleFor(c => c.BootcampId).NotEmpty();
    }
}
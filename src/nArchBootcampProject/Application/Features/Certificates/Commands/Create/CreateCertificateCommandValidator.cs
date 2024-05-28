using FluentValidation;

namespace Application.Features.Certificates.Commands.Create;

public class CreateCertificateCommandValidator : AbstractValidator<CreateCertificateCommand>
{
    public CreateCertificateCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        //RuleFor(c => c.CreateCertificateDto).NotEmpty();
    }
}
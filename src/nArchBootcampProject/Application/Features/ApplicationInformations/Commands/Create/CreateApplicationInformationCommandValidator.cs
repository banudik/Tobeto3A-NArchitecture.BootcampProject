using FluentValidation;

namespace Application.Features.ApplicationInformations.Commands.Create;

public class CreateApplicationInformationCommandValidator : AbstractValidator<CreateApplicationInformationCommand>
{
    public CreateApplicationInformationCommandValidator()
    {
        RuleFor(c => c.ApplicantId).NotEmpty();
        RuleFor(c => c.BootcampId).NotEmpty();
        RuleFor(c => c.ApplicationStateId).NotEmpty();
    }
}

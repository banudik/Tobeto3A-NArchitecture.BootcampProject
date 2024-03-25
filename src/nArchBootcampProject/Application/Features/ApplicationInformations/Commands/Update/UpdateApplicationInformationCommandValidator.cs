using FluentValidation;

namespace Application.Features.ApplicationInformations.Commands.Update;

public class UpdateApplicationInformationCommandValidator : AbstractValidator<UpdateApplicationInformationCommand>
{
    public UpdateApplicationInformationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ApplicantId).NotEmpty();
        RuleFor(c => c.BootcampId).NotEmpty();
        RuleFor(c => c.ApplicationStateId).NotEmpty();
    }
}

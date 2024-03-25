using FluentValidation;

namespace Application.Features.ApplicationStateInformations.Commands.Update;

public class UpdateApplicationStateInformationCommandValidator : AbstractValidator<UpdateApplicationStateInformationCommand>
{
    public UpdateApplicationStateInformationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}

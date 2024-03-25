using FluentValidation;

namespace Application.Features.ApplicationStateInformations.Commands.Create;

public class CreateApplicationStateInformationCommandValidator : AbstractValidator<CreateApplicationStateInformationCommand>
{
    public CreateApplicationStateInformationCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}

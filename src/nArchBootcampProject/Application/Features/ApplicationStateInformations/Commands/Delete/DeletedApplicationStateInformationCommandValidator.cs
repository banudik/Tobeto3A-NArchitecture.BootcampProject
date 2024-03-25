using FluentValidation;

namespace Application.Features.ApplicationStateInformations.Commands.Delete;

public class DeleteApplicationStateInformationCommandValidator : AbstractValidator<DeleteApplicationStateInformationCommand>
{
    public DeleteApplicationStateInformationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}

using FluentValidation;

namespace Application.Features.Instructors.Commands.Delete;

public class DeleteInstructorCommandValidator : AbstractValidator<DeleteInstructorCommand>
{
    public DeleteInstructorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}

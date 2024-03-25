using FluentValidation;

namespace Application.Features.Instructors.Commands.Create;

public class CreateInstructorCommandValidator : AbstractValidator<CreateInstructorCommand>
{
    public CreateInstructorCommandValidator()
    {
        RuleFor(c => c.CompanyName).NotEmpty();
    }
}

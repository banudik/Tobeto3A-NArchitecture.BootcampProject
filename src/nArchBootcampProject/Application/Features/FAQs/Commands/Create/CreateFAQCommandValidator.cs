using FluentValidation;

namespace Application.Features.FAQs.Commands.Create;

public class CreateFAQCommandValidator : AbstractValidator<CreateFAQCommand>
{
    public CreateFAQCommandValidator()
    {
        RuleFor(c => c.Question).NotEmpty();
        RuleFor(c => c.Answer).NotEmpty();
        RuleFor(c => c.Category).NotEmpty();
    }
}
using FluentValidation;

namespace Application.Features.FAQs.Commands.Update;

public class UpdateFAQCommandValidator : AbstractValidator<UpdateFAQCommand>
{
    public UpdateFAQCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Question).NotEmpty();
        RuleFor(c => c.Answer).NotEmpty();
        RuleFor(c => c.Category).NotEmpty();
    }
}
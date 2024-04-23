using FluentValidation;

namespace Application.Features.FAQs.Commands.Delete;

public class DeleteFAQCommandValidator : AbstractValidator<DeleteFAQCommand>
{
    public DeleteFAQCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
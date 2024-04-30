using FluentValidation;

namespace Application.Features.Chapters.Commands.Delete;

public class DeleteChapterCommandValidator : AbstractValidator<DeleteChapterCommand>
{
    public DeleteChapterCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
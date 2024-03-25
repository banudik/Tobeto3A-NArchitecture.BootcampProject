using FluentValidation;

namespace Application.Features.BootcampImages.Commands.Delete;

public class DeleteBootcampImageCommandValidator : AbstractValidator<DeleteBootcampImageCommand>
{
    public DeleteBootcampImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}

using FluentValidation;

namespace Application.Features.BootcampImages.Commands.Create;

public class CreateBootcampImageCommandValidator : AbstractValidator<CreateBootcampImageCommand>
{
    public CreateBootcampImageCommandValidator()
    {
        RuleFor(c => c.BootcampId).NotEmpty();
        RuleFor(c => c.ImagePath).NotEmpty();
    }
}

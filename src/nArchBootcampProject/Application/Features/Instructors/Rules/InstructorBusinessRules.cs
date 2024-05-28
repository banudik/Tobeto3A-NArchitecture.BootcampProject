using Application.Features.Instructors.Constants;
using Application.Features.Users.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using NArchitecture.Core.Security.Hashing;

namespace Application.Features.Instructors.Rules;

public class InstructorBusinessRules : BaseBusinessRules
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly ILocalizationService _localizationService;

    public InstructorBusinessRules(IInstructorRepository instructorRepository, ILocalizationService localizationService)
    {
        _instructorRepository = instructorRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, InstructorsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task InstructorShouldExistWhenSelected(Instructor? instructor)
    {
        if (instructor == null)
            await throwBusinessException(InstructorsBusinessMessages.InstructorNotExists);
    }

    public async Task InstructorIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Instructor? instructor = await _instructorRepository.GetAsync(
            predicate: i => i.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await InstructorShouldExistWhenSelected(instructor);
    }

    public async Task InstructorPasswordShouldBeMatched(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            await throwBusinessException(UsersMessages.PasswordDontMatch);
    }

    public async Task InstructorEmailShouldNotExistsWhenUpdate(Guid id, string email)
    {
        bool doesExists = await _instructorRepository.AnyAsync(predicate: u => u.Id != id && u.Email == email);
        if (doesExists)
            await throwBusinessException(UsersMessages.UserMailAlreadyExists);
    }
}

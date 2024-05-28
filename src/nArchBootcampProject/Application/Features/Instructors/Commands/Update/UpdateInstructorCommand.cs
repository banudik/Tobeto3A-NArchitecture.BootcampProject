using Application.Features.Employees.Constants;
using Application.Features.Employees.Rules;
using Application.Features.Instructors.Constants;
using Application.Features.Instructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.Security.Hashing;
using static Application.Features.Instructors.Constants.InstructorsOperationClaims;

namespace Application.Features.Instructors.Commands.Update;

public class UpdateInstructorCommand
    : IRequest<UpdatedInstructorResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Description { get; set; }
    public string NationalIdentity { get; set; }
    public string CompanyName { get; set; }
    public string Email { get; set; }
    public string? Password { get; set; }
    public string? NewPassword { get; set; }

    public string[] Roles => [Admin, Write, InstructorsOperationClaims.Update, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetInstructors"];

    public class UpdateInstructorCommandHandler : IRequestHandler<UpdateInstructorCommand, UpdatedInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly InstructorBusinessRules _instructorBusinessRules;

        public UpdateInstructorCommandHandler(
            IMapper mapper,
            IInstructorRepository instructorRepository,
            InstructorBusinessRules instructorBusinessRules
        )
        {
            _mapper = mapper;
            _instructorRepository = instructorRepository;
            _instructorBusinessRules = instructorBusinessRules;
        }

        public async Task<UpdatedInstructorResponse> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
        {
            Instructor? instructor = await _instructorRepository.GetAsync(
                predicate: i => i.Id == request.Id,
                cancellationToken: cancellationToken
            );

            await _instructorBusinessRules.InstructorShouldExistWhenSelected(instructor);
            await _instructorBusinessRules.InstructorEmailShouldNotExistsWhenUpdate(instructor!.Id, instructor.Email);
            instructor = _mapper.Map(request, instructor);

            if (request.NewPassword != null && !string.IsNullOrWhiteSpace(request.NewPassword))
            {
                //await _instructorBusinessRules.InstructorPasswordShouldBeMatched(user: instructor!, request.Password);
                HashingHelper.CreatePasswordHash(
                    request.NewPassword,
                    passwordHash: out byte[] passwordHash,
                    passwordSalt: out byte[] passwordSalt
                );
                instructor!.PasswordHash = passwordHash;
                instructor!.PasswordSalt = passwordSalt;
            }

            await _instructorRepository.UpdateAsync(instructor!);

            UpdatedInstructorResponse response = _mapper.Map<UpdatedInstructorResponse>(instructor);
            return response;
        }
    }
}

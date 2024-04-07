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
using static Application.Features.Instructors.Constants.InstructorsOperationClaims;

namespace Application.Features.Instructors.Commands.Create;

public class CreateInstructorCommand
    : IRequest<CreatedInstructorResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string CompanyName { get; set; }

    public string[] Roles => [Admin, Write, InstructorsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetInstructors"];

    public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, CreatedInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly InstructorBusinessRules _instructorBusinessRules;

        public CreateInstructorCommandHandler(
            IMapper mapper,
            IInstructorRepository instructorRepository,
            InstructorBusinessRules instructorBusinessRules
        )
        {
            _mapper = mapper;
            _instructorRepository = instructorRepository;
            _instructorBusinessRules = instructorBusinessRules;
        }

        public async Task<CreatedInstructorResponse> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);

            await _instructorRepository.AddAsync(instructor);

            CreatedInstructorResponse response = _mapper.Map<CreatedInstructorResponse>(instructor);
            return response;
        }
    }
}

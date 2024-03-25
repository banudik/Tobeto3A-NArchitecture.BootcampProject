using Application.Features.Instructors.Constants;
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

namespace Application.Features.Instructors.Commands.Delete;

public class DeleteInstructorCommand
    : IRequest<DeletedInstructorResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, InstructorsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetInstructors"];

    public class DeleteInstructorCommandHandler : IRequestHandler<DeleteInstructorCommand, DeletedInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly InstructorBusinessRules _instructorBusinessRules;

        public DeleteInstructorCommandHandler(
            IMapper mapper,
            IInstructorRepository instructorRepository,
            InstructorBusinessRules instructorBusinessRules
        )
        {
            _mapper = mapper;
            _instructorRepository = instructorRepository;
            _instructorBusinessRules = instructorBusinessRules;
        }

        public async Task<DeletedInstructorResponse> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
        {
            Instructor? instructor = await _instructorRepository.GetAsync(
                predicate: i => i.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _instructorBusinessRules.InstructorShouldExistWhenSelected(instructor);

            await _instructorRepository.DeleteAsync(instructor!);

            DeletedInstructorResponse response = _mapper.Map<DeletedInstructorResponse>(instructor);
            return response;
        }
    }
}

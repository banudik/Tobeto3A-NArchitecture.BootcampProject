using Application.Features.Instructors.Constants;
using Application.Features.Instructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using static Application.Features.Instructors.Constants.InstructorsOperationClaims;

namespace Application.Features.Instructors.Queries.GetById;

public class GetByIdInstructorQuery : IRequest<GetByIdInstructorResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdInstructorQueryHandler : IRequestHandler<GetByIdInstructorQuery, GetByIdInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly InstructorBusinessRules _instructorBusinessRules;

        public GetByIdInstructorQueryHandler(
            IMapper mapper,
            IInstructorRepository instructorRepository,
            InstructorBusinessRules instructorBusinessRules
        )
        {
            _mapper = mapper;
            _instructorRepository = instructorRepository;
            _instructorBusinessRules = instructorBusinessRules;
        }

        public async Task<GetByIdInstructorResponse> Handle(GetByIdInstructorQuery request, CancellationToken cancellationToken)
        {
            Instructor? instructor = await _instructorRepository.GetAsync(
                predicate: i => i.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _instructorBusinessRules.InstructorShouldExistWhenSelected(instructor);

            GetByIdInstructorResponse response = _mapper.Map<GetByIdInstructorResponse>(instructor);
            return response;
        }
    }
}

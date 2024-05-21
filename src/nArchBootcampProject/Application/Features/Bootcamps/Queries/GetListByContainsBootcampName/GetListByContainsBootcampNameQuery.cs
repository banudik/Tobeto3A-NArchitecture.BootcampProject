using Application.Features.Applicants.Constants;
using Application.Features.Bootcamps.Constants;
using Application.Features.Employees.Constants;
using Application.Features.Instructors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System.Linq;
using static Application.Features.Bootcamps.Constants.BootcampsOperationClaims;

namespace Application.Features.Bootcamps.Queries.GetList;

public class GetListByContainsBootcampNameQuery : IRequest<GetListResponse<GetListBootcampListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public string? Search { get; set; }
    public Guid? InstructorId { get; set; }
    public string[] Roles => [Admin, Read, ApplicantsOperationClaims.ApplicantRole, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByContainsBootcampNameQueryHandler : IRequestHandler<GetListByContainsBootcampNameQuery, GetListResponse<GetListBootcampListItemDto>>
    {
        private readonly IBootcampRepository _bootcampRepository;
        private readonly IMapper _mapper;

        public GetListByContainsBootcampNameQueryHandler(IBootcampRepository bootcampRepository, IMapper mapper)
        {
            _bootcampRepository = bootcampRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBootcampListItemDto>> Handle(GetListByContainsBootcampNameQuery request, CancellationToken cancellationToken)
        {
            if (request.Search == null || request.Search == "")
            {
                IPaginate<Bootcamp> bootcamps = await _bootcampRepository.GetListAsync(
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken,
                    include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState).Include(x => x.BootcampImage)

);

                GetListResponse<GetListBootcampListItemDto> response = _mapper.Map<GetListResponse<GetListBootcampListItemDto>>(bootcamps);
                return response;
            }
            else if ((request.Search != null || request.Search != "") && request.InstructorId != null)
            {
                IPaginate<Bootcamp> bootcamps = await _bootcampRepository.GetListAsync(
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken,
                    include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState).Include(x => x.BootcampImage),
                    predicate: z => z.Name.ToLower().Contains(request.Search.ToLower()) && z.InstructorId == request.InstructorId);

                GetListResponse<GetListBootcampListItemDto> response = _mapper.Map<GetListResponse<GetListBootcampListItemDto>>(bootcamps);
                return response;
            }
            else
            {
                IPaginate<Bootcamp> bootcamps = await _bootcampRepository.GetListAsync(
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken,
                    include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState).Include(x => x.BootcampImage),
                    predicate: z => z.Name.ToLower().Contains(request.Search.ToLower()));

                GetListResponse<GetListBootcampListItemDto> response = _mapper.Map<GetListResponse<GetListBootcampListItemDto>>(bootcamps);
                return response;
            }

        }
    }
}

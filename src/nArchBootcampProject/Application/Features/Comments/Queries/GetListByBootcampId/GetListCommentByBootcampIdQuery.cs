using Application.Features.Applicants.Constants;
using Application.Features.Comments.Constants;
using Application.Features.Employees.Constants;
using Application.Features.Instructors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Queries.GetListByBootcampId;

public class GetListCommentByBootcampIdQuery : IRequest<GetListResponse<GetListCommentListByBootcampIdItemDto>>,  ICachableRequest
{
    public int BootcampId { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [CommentsOperationClaims.Admin, CommentsOperationClaims.Read, ApplicantsOperationClaims.ApplicantRole, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListComments({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetComments";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCommentByBootcampIdQueryHandler : IRequestHandler<GetListCommentByBootcampIdQuery, GetListResponse<GetListCommentListByBootcampIdItemDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetListCommentByBootcampIdQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCommentListByBootcampIdItemDto>> Handle(GetListCommentByBootcampIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Comment> comments = await _commentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                include: x => x.Include(p => p.Bootcamp).Include(p => p.User),
                predicate:x=>x.BootcampId == request.BootcampId && x.Status == true
            );

            GetListResponse<GetListCommentListByBootcampIdItemDto> response = _mapper.Map<GetListResponse<GetListCommentListByBootcampIdItemDto>>(comments);
            return response;
        }
    }
}

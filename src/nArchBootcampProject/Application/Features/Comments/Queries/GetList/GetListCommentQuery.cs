using Application.Features.Comments.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Comments.Constants.CommentsOperationClaims;

namespace Application.Features.Comments.Queries.GetList;

public class GetListCommentQuery : IRequest<GetListResponse<GetListCommentListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListComments({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetComments";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCommentQueryHandler : IRequestHandler<GetListCommentQuery, GetListResponse<GetListCommentListItemDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetListCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCommentListItemDto>> Handle(GetListCommentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Comment> comments = await _commentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCommentListItemDto> response = _mapper.Map<GetListResponse<GetListCommentListItemDto>>(comments);
            return response;
        }
    }
}
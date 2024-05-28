using Application.Features.Comments.Constants;
using Application.Features.Comments.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Queries.GetListDynamic;
public class GetListCommentDynamicQuery : IRequest<GetListResponse<GetListCommentListItemDto>>/*, ISecuredRequest, ICachableRequest*/

{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery Dynamic { get; set; }

    public string[] Roles => [CommentsOperationClaims.Admin, CommentsOperationClaims.Write, CommentsOperationClaims.Read];

    //public bool BypassCache { get; }
    //public string? CacheKey => $"GetListCommentsDynamic({PageRequest.PageIndex},{PageRequest.PageSize})";
    //public string? CacheGroupKey => "GetCommentsDynamic";
    //public TimeSpan? SlidingExpiration { get; }

    public class GetListCommentDynamicQueryHandler : IRequestHandler<GetListCommentDynamicQuery, GetListResponse<GetListCommentListItemDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetListCommentDynamicQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCommentListItemDto>> Handle(
            GetListCommentDynamicQuery request,
            CancellationToken cancellationToken
        )

        {
            IPaginate<Comment> comments = await _commentRepository.GetListByDynamicAsync(
                request.Dynamic,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCommentListItemDto> response = _mapper.Map<GetListResponse<GetListCommentListItemDto>>(comments);
            return response;
        }
    }
}

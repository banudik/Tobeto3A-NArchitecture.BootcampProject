using Application.Features.Comments.Commands.Create;
using Application.Features.Comments.Commands.Delete;
using Application.Features.Comments.Commands.Update;
using Application.Features.Comments.Queries.GetById;
using Application.Features.Comments.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Comments.Queries.GetListByBootcampId;

namespace Application.Features.Comments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Comment, CreateCommentCommand>().ReverseMap();
        CreateMap<Comment, CreatedCommentResponse>().ReverseMap();
        CreateMap<Comment, UpdateCommentCommand>().ReverseMap();
        CreateMap<Comment, UpdatedCommentResponse>().ReverseMap();
        CreateMap<Comment, DeleteCommentCommand>().ReverseMap();
        CreateMap<Comment, DeletedCommentResponse>().ReverseMap();
        CreateMap<Comment, GetByIdCommentResponse>().ReverseMap();
        CreateMap<Comment, GetListCommentListItemDto>().ReverseMap();
        CreateMap<Comment, GetListCommentListByBootcampIdItemDto>().ReverseMap();
        CreateMap<IPaginate<Comment>, GetListResponse<GetListCommentListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Comment>, GetListResponse<GetListCommentListByBootcampIdItemDto>>().ReverseMap();
    }
}
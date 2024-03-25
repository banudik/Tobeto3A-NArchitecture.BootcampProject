using Application.Features.Bootcamps.Commands.Create;
using Application.Features.Bootcamps.Commands.Delete;
using Application.Features.Bootcamps.Commands.Update;
using Application.Features.Bootcamps.Queries.GetById;
using Application.Features.Bootcamps.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Bootcamps.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Bootcamp, CreateBootcampCommand>().ReverseMap();
        CreateMap<Bootcamp, CreatedBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, UpdateBootcampCommand>().ReverseMap();
        CreateMap<Bootcamp, UpdatedBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, DeleteBootcampCommand>().ReverseMap();
        CreateMap<Bootcamp, DeletedBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, GetByIdBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, GetListBootcampListItemDto>().ReverseMap();
        CreateMap<IPaginate<Bootcamp>, GetListResponse<GetListBootcampListItemDto>>().ReverseMap();
    }
}

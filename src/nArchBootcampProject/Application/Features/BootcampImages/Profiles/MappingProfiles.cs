using Application.Features.BootcampImages.Commands.Create;
using Application.Features.BootcampImages.Commands.Delete;
using Application.Features.BootcampImages.Commands.Update;
using Application.Features.BootcampImages.Queries.GetById;
using Application.Features.BootcampImages.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BootcampImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BootcampImage, CreateBootcampImageCommand>().ReverseMap();
        CreateMap<BootcampImage, CreatedBootcampImageResponse>().ReverseMap();
        CreateMap<BootcampImage, UpdateBootcampImageCommand>().ReverseMap();
        CreateMap<BootcampImage, UpdatedBootcampImageResponse>().ReverseMap();
        CreateMap<BootcampImage, DeleteBootcampImageCommand>().ReverseMap();
        CreateMap<BootcampImage, DeletedBootcampImageResponse>().ReverseMap();
        CreateMap<BootcampImage, GetByIdBootcampImageResponse>().ReverseMap();
        CreateMap<BootcampImage, GetListBootcampImageListItemDto>().ReverseMap();
        CreateMap<IPaginate<BootcampImage>, GetListResponse<GetListBootcampImageListItemDto>>().ReverseMap();
    }
}

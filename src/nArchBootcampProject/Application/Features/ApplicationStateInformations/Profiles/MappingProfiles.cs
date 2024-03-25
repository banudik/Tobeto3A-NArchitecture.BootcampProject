using Application.Features.ApplicationStateInformations.Commands.Create;
using Application.Features.ApplicationStateInformations.Commands.Delete;
using Application.Features.ApplicationStateInformations.Commands.Update;
using Application.Features.ApplicationStateInformations.Queries.GetById;
using Application.Features.ApplicationStateInformations.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ApplicationStateInformations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ApplicationStateInformation, CreateApplicationStateInformationCommand>().ReverseMap();
        CreateMap<ApplicationStateInformation, CreatedApplicationStateInformationResponse>().ReverseMap();
        CreateMap<ApplicationStateInformation, UpdateApplicationStateInformationCommand>().ReverseMap();
        CreateMap<ApplicationStateInformation, UpdatedApplicationStateInformationResponse>().ReverseMap();
        CreateMap<ApplicationStateInformation, DeleteApplicationStateInformationCommand>().ReverseMap();
        CreateMap<ApplicationStateInformation, DeletedApplicationStateInformationResponse>().ReverseMap();
        CreateMap<ApplicationStateInformation, GetByIdApplicationStateInformationResponse>().ReverseMap();
        CreateMap<ApplicationStateInformation, GetListApplicationStateInformationListItemDto>().ReverseMap();
        CreateMap<IPaginate<ApplicationStateInformation>, GetListResponse<GetListApplicationStateInformationListItemDto>>()
            .ReverseMap();
    }
}

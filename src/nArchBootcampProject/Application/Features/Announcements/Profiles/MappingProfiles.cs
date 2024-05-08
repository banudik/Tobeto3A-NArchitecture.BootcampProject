using Application.Features.Announcements.Commands.Create;
using Application.Features.Announcements.Commands.Delete;
using Application.Features.Announcements.Commands.Update;
using Application.Features.Announcements.Queries.GetById;
using Application.Features.Announcements.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Announcements.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAnnouncementCommand, Announcement>();
        CreateMap<Announcement, CreatedAnnouncementResponse>();

        CreateMap<UpdateAnnouncementCommand, Announcement>();
        CreateMap<Announcement, UpdatedAnnouncementResponse>();

        CreateMap<DeleteAnnouncementCommand, Announcement>();
        CreateMap<Announcement, DeletedAnnouncementResponse>();

        CreateMap<Announcement, GetByIdAnnouncementResponse>();

        CreateMap<Announcement, GetListAnnouncementListItemDto>();
        CreateMap<IPaginate<Announcement>, GetListResponse<GetListAnnouncementListItemDto>>();
    }
}
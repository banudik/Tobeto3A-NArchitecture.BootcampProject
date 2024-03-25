using Application.Features.Instructors.Commands.Create;
using Application.Features.Instructors.Commands.Delete;
using Application.Features.Instructors.Commands.Update;
using Application.Features.Instructors.Queries.GetById;
using Application.Features.Instructors.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Instructors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Instructor, CreateInstructorCommand>().ReverseMap();
        CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();
        CreateMap<Instructor, UpdateInstructorCommand>().ReverseMap();
        CreateMap<Instructor, UpdatedInstructorResponse>().ReverseMap();
        CreateMap<Instructor, DeleteInstructorCommand>().ReverseMap();
        CreateMap<Instructor, DeletedInstructorResponse>().ReverseMap();
        CreateMap<Instructor, GetByIdInstructorResponse>().ReverseMap();
        CreateMap<Instructor, GetListInstructorListItemDto>().ReverseMap();
        CreateMap<IPaginate<Instructor>, GetListResponse<GetListInstructorListItemDto>>().ReverseMap();
    }
}

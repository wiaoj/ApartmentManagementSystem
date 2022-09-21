using Application.Handlers.Users.Commands.Create;
using Application.Handlers.Users.Commands.Delete;
using Application.Handlers.Users.Commands.Update;
using Application.Handlers.Users.Dtos.Commands;
using Application.Handlers.Users.Dtos.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Handlers.Users.Mapping;
public class MappingProfiles : Profile {
    public MappingProfiles() {
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, CreatedUserDto>().ReverseMap();

        CreateMap<User, DeleteUserCommand>().ReverseMap();
        CreateMap<User, DeletedUserDto>().ReverseMap();

        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<User, UpdatedUserDto>().ReverseMap();

        CreateMap<User, GetAllUserDto>().ReverseMap();
        CreateMap<User, GetByIdUserDto>()
            .ForMember(x => x.PhoneNumbers, opt => opt.MapFrom(x => x.PhoneNumbers))
            .ForMember(x => x.Vehicles, opt => opt.MapFrom(x => x.Vehicles))
            .ReverseMap();
    }
}
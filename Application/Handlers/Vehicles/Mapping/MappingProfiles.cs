using Application.Handlers.Vehicles.Commands.Create;
using Application.Handlers.Vehicles.Commands.Delete;
using Application.Handlers.Vehicles.Commands.Update;
using Application.Handlers.Vehicles.Dtos.Commands;
using Application.Handlers.Vehicles.Dtos.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Handlers.Vehicles.Mapping;
public class MappingProfiles : Profile {
    public MappingProfiles() {
        CreateMap<Vehicle, CreateVehicleCommand>()
            .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.CarOwnerId))
            .ReverseMap();
        CreateMap<Vehicle, CreatedVehicleDto>()
            .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.CarOwnerId))
            .ReverseMap();

        CreateMap<Vehicle, DeleteVehicleCommand>().ReverseMap();
        CreateMap<Vehicle, DeletedVehicleDto>().ReverseMap();

        CreateMap<Vehicle, UpdateVehicleCommand>()
            .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.CarOwnerId))
            .ReverseMap();
        CreateMap<Vehicle, UpdatedVehicleDto>()
            .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.CarOwnerId))
            .ReverseMap();

        CreateMap<Vehicle, GetAllVehicleDto>().ReverseMap();
        CreateMap<Vehicle, GetByIdVehicleDto>().ReverseMap();
        CreateMap<Vehicle, GetByUserIdVehicleDto>().ReverseMap();
    }
}
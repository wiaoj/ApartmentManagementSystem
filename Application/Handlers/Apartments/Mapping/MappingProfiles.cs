using Application.Handlers.Apartments.Commands.Create;
using Application.Handlers.Apartments.Commands.Delete;
using Application.Handlers.Apartments.Commands.Update;
using Application.Handlers.Apartments.Dtos.Commands;
using Application.Handlers.Apartments.Dtos.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Handlers.Apartments.Mapping;
public class MappingProfiles : Profile {
    public MappingProfiles() {
        CreateMap<Apartment, CreateApartmentCommand>().ReverseMap();
        CreateMap<Apartment, CreatedApartmentDto>().ReverseMap();

        CreateMap<Apartment, DeleteApartmentCommand>().ReverseMap();
        CreateMap<Apartment, DeletedApartmentDto>().ReverseMap();

        CreateMap<Apartment, UpdateApartmentCommand>().ReverseMap();
        CreateMap<Apartment, UpdatedApartmentDto>().ReverseMap();

        CreateMap<Apartment, GetAllApartmentDto>().ReverseMap();
        CreateMap<Apartment, GetByIdApartmentDto>().ReverseMap();
        CreateMap<Apartment, GetByUserIdApartmentDto>().ReverseMap();
    }
}
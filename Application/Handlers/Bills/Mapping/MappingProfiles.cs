using Application.Handlers.Bills.Commands.Create;
using Application.Handlers.Bills.Commands.Delete;
using Application.Handlers.Bills.Commands.Update;
using Application.Handlers.Bills.Dtos.Commands;
using Application.Handlers.Bills.Dtos.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Handlers.Bills.Mapping;
public class MappingProfiles : Profile {
    public MappingProfiles() {
        CreateMap<Bill, CreateBillCommand>().ReverseMap();
        CreateMap<Bill, CreatedBillDto>().ReverseMap();

        CreateMap<Bill, DeleteBillCommand>().ReverseMap();
        CreateMap<Bill, DeletedBillDto>().ReverseMap();

        CreateMap<Bill, UpdateBillCommand>().ReverseMap();
        CreateMap<Bill, UpdatedBillDto>().ReverseMap();

        CreateMap<Bill, GetAllBillDto>().ReverseMap();
        CreateMap<Bill, GetByIdBillDto>().ReverseMap();
        CreateMap<Bill, GetByUserIdBillDto>().ReverseMap();
    }
}
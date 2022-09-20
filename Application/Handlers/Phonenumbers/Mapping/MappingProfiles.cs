using Application.Handlers.PhoneNumbers.Commands.Create;
using Application.Handlers.PhoneNumbers.Commands.Delete;
using Application.Handlers.PhoneNumbers.Commands.Update;
using Application.Handlers.PhoneNumbers.Dtos.Commands;
using Application.Handlers.PhoneNumbers.Constants;
using AutoMapper;
using Domain.Entities;

namespace Application.Handlers.PhoneNumbers.Mapping;
public class MappingProfiles : Profile{
	public MappingProfiles() {
		CreateMap<PhoneNumber, CreatePhoneNumberCommand>()
			.ForMember(x => x.UserId, opt => opt.MapFrom(x => x.PhoneNumberUserId))
			.ReverseMap();
		CreateMap<PhoneNumber, CreatedPhoneNumberDto>()
			.ForMember(x => x.UserId, opt => opt.MapFrom(x => x.PhoneNumberUserId))
            .ReverseMap();

		CreateMap<PhoneNumber, DeletePhoneNumberCommand>().ReverseMap();
		CreateMap<PhoneNumber, DeletedPhoneNumberDto>().ReverseMap();

		CreateMap<PhoneNumber, UpdatePhoneNumberCommand>().ReverseMap();
		CreateMap<PhoneNumber, UpdatedPhoneNumberDto>().ReverseMap();
	}
}
using Application.Handlers.Phonenumbers.Commands.Create;
using Application.Handlers.Phonenumbers.Commands.Delete;
using Application.Handlers.Phonenumbers.Commands.Update;
using Application.Handlers.Phonenumbers.Dtos.Commands;
using Application.Handlers.PhoneNumbers.Constants;
using AutoMapper;
using Domain.Entities;

namespace Application.Handlers.Phonenumbers.Mapping;
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
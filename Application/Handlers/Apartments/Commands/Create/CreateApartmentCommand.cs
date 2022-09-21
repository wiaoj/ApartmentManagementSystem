using Application.Handlers.Apartments.BusinessRules;
using Application.Handlers.Apartments.Constants;
using Application.Handlers.Apartments.Dtos.Commands;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using ApartmentState = Domain.Enums.ApartmentState;

namespace Application.Handlers.Apartments.Commands.Create;

public class CreateApartmentCommand : IRequest<CreatedApartmentDto> {
    public String Number { get; set; }
    public String BlockNo { get; set; }
    public String Floor { get; set; }
    public String Type { get; set; }
    public ApartmentState ApartmentState { get; set; }

    internal class CreateCommandHandler : IRequestHandler<CreateApartmentCommand, CreatedApartmentDto> {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly ApartmentBusinessRules _apartmentBusinessRules;
        private readonly IMapper _mapper;

        public CreateCommandHandler(IApartmentRepository apartmentRepository, ApartmentBusinessRules apartmentBusinessRules, IMapper mapper) {
            _apartmentRepository = apartmentRepository;
            _apartmentBusinessRules = apartmentBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreatedApartmentDto> Handle(CreateApartmentCommand request, CancellationToken cancellationToken) {
            //await _apartmentBusinessRules.ApartmentNotBeDuplicatedWhenInserted(request.?);

            Apartment mappedApartment = _mapper.Map<Apartment>(request);
            Apartment createdApartment = await _apartmentRepository.AddAsync(mappedApartment);

            CreatedApartmentDto createdApartmentDto = _mapper.Map<CreatedApartmentDto>(createdApartment);
            createdApartmentDto.Message = ApartmentMessageConstants.Created;

            return createdApartmentDto;
        }
    }
}
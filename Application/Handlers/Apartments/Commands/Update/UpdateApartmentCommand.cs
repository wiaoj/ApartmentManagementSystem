using Application.Handlers.Apartments.BusinessRules;
using Application.Handlers.Apartments.Constants;
using Application.Handlers.Apartments.Dtos.Commands;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using ApartmentState = Domain.Enums.ApartmentState;

namespace Application.Handlers.Apartments.Commands.Update;

public class UpdateApartmentCommand : IRequest<UpdatedApartmentDto> {
    public Guid Id { get; set; }
    public String Number { get; set; }
    public String BlockNo { get; set; }
    public String Floor { get; set; }
    public String Type { get; set; }
    public ApartmentState ApartmentState { get; set; }

    internal class UpdateApartmentCommandHandler : IRequestHandler<UpdateApartmentCommand, UpdatedApartmentDto> {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly ApartmentBusinessRules _apartmentBusinessRules;
        private readonly IMapper _mapper;

        public UpdateApartmentCommandHandler(IApartmentRepository apartmentRepository, ApartmentBusinessRules apartmentBusinessRules, IMapper mapper) {
            _apartmentRepository = apartmentRepository;
            _apartmentBusinessRules = apartmentBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdatedApartmentDto> Handle(UpdateApartmentCommand request, CancellationToken cancellationToken) {
            await _apartmentBusinessRules.ApartmentShouldExistWhenRequestId(request.Id);

            Apartment mappedApartment = _mapper.Map<Apartment>(request);
            Apartment updatedApartment = await _apartmentRepository.UpdateAsync(mappedApartment);

            UpdatedApartmentDto updatedApartmentDto = _mapper.Map<UpdatedApartmentDto>(updatedApartment);
            updatedApartmentDto.Message = ApartmentMessageConstants.Updated;

            return updatedApartmentDto;
        }
    }
}
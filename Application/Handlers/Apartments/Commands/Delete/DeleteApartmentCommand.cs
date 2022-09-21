using Application.Handlers.Apartments.BusinessRules;
using Application.Handlers.Apartments.Constants;
using Application.Handlers.Apartments.Dtos.Commands;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Apartments.Commands.Delete;

public class DeleteApartmentCommand : IRequest<DeletedApartmentDto> {
    public Guid Id { get; set; }

    internal class DeleteCommandHandler : IRequestHandler<DeleteApartmentCommand, DeletedApartmentDto> {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly ApartmentBusinessRules _apartmentBusinessRules;
        private readonly IMapper _mapper;

        public DeleteCommandHandler(IApartmentRepository apartmentRepository, ApartmentBusinessRules apartmentBusinessRules, IMapper mapper) {
            _apartmentRepository = apartmentRepository;
            _apartmentBusinessRules = apartmentBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeletedApartmentDto> Handle(DeleteApartmentCommand request, CancellationToken cancellationToken) {
            await _apartmentBusinessRules.ApartmentShouldExistWhenRequestId(request.Id);

            Apartment mappedApartment = _mapper.Map<Apartment>(request);
            Apartment deletedApartment = await _apartmentRepository.DeleteAsync(mappedApartment.Id);

            DeletedApartmentDto deletedApartmentDto = _mapper.Map<DeletedApartmentDto>(deletedApartment);
            deletedApartmentDto.Message = ApartmentMessageConstants.Deleted;

            return deletedApartmentDto;
        }
    }
}